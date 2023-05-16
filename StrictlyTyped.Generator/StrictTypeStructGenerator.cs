using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using StrictlyTyped.Generator.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace StrictlyTyped.Generator;

[Generator]
public class StrictTypeGenerator : IIncrementalGenerator
{
    private record RecordToGenerate(string Name, string NameSpace, List<string> EnclosingClasses);

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValuesProvider<(RecordDeclarationSyntax record, string type)> recordDeclarations = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: (s, _) => _isSyntaxTargetForGeneration(s),
                transform: (ctx, _) => _getSemanticTargetForGeneration(ctx))
            .Where(m => m.record is not null)!;

        IncrementalValueProvider<(Compilation, ImmutableArray<(RecordDeclarationSyntax record, string type)>)> compilationAndRecords
            = context.CompilationProvider.Combine(recordDeclarations.Collect());

        context.RegisterSourceOutput(compilationAndRecords,
            static (spc, source) => _execute(source.Item1, source.Item2, spc));
    }

    private static (RecordDeclarationSyntax? record, string type) _getSemanticTargetForGeneration(GeneratorSyntaxContext context)
    {
        var recordDeclarationSyntax = (RecordDeclarationSyntax)context.Node;

        foreach (AttributeListSyntax attributeListSyntax in recordDeclarationSyntax.AttributeLists)
        {
            foreach (AttributeSyntax attributeSyntax in attributeListSyntax.Attributes)
            {
                if (context.SemanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
                {
                    continue;
                }

                INamedTypeSymbol attributeContainingTypeSymbol = attributeSymbol.ContainingType;
                string fullName = attributeContainingTypeSymbol.ToDisplayString();

                if (fullName.StartsWith("StrictlyTyped.Strict"))
                {
                    return (recordDeclarationSyntax, fullName.Replace("StrictlyTyped.Strict", string.Empty).Replace("Attribute", string.Empty));
                }
            }
        }

        return (record: null, string.Empty);
    }

    static bool _isSyntaxTargetForGeneration(SyntaxNode node) => 
        node is RecordDeclarationSyntax m && m.AttributeLists.Count > 0;

    static void _execute(Compilation compilation, ImmutableArray<(RecordDeclarationSyntax record, string type)> records, SourceProductionContext context)
    {
        if (records.IsDefaultOrEmpty)
        {
            return;
        }

        IEnumerable<(RecordDeclarationSyntax record, string type)> distinctRecords = records.Distinct();

        var recordsToGenerate = _generateRecords(compilation, distinctRecords, context.CancellationToken);

        foreach (var (fileName, content) in recordsToGenerate)
        {
            context.AddSource($"{fileName}.generated.cs", SourceText.From(content, Encoding.UTF8));
        }
    }

    private static readonly Lazy<string> _boolTemplate = new(() => Resources.StrictBoolTemplate);
    private static readonly Lazy<string> _signedNumberTemplate = new(() => Resources.SignedNumberTemplate);
    private static readonly Lazy<string> _unsignedNumberTemplate = new(() => Resources.UnsignedNumberTemplate);
    private static readonly Lazy<string> _dateTimeTemplate = new(() => Resources.StrictDateTimeTemplate);
    private static readonly Lazy<string> _guidTemplate = new(() => Resources.StrictGuidTemplate);
    private static readonly Lazy<string> _stringTemplate = new(() => Resources.StrictStringTemplate);
    private static readonly Lazy<string> _dateOnlyTemplate = new(() => Resources.StrictDateOnlyTemplate);

    private static IEnumerable<(string fileName, string content)> _generateRecords(Compilation compilation, IEnumerable<(RecordDeclarationSyntax record, string type)> distinctRecords, CancellationToken cancellationToken)
    {
        var recordDeclarationSyntax = distinctRecords.ToArray();
        for (int i = 0; i < recordDeclarationSyntax.Length; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            SemanticModel semanticModel = compilation.GetSemanticModel(recordDeclarationSyntax[i].record.SyntaxTree);
            if (semanticModel.GetDeclaredSymbol(recordDeclarationSyntax[i].record, cancellationToken) is not INamedTypeSymbol recordSymbol)
            {
                continue;
            }
            string recordName = recordSymbol.ToString();
            string name = recordSymbol.Name;
            string nameSpace = SyntaxNodeHelper.GetNamespace(recordDeclarationSyntax[i].record, cancellationToken);
            var parents = SyntaxNodeHelper.GetParentClasses(recordDeclarationSyntax[i].record, cancellationToken);

            (string template, string typeName, string informalName, string? formalName) = recordDeclarationSyntax[i].type switch
            {
                "Byte" => (_unsignedNumberTemplate.Value, name, "Byte", null),
                "DateOnly" => (_dateOnlyTemplate.Value, name, "DateOnly", null),
                "DateTime" => (_dateTimeTemplate.Value, name, "DateTime", null),
                "Decimal" => (_signedNumberTemplate.Value, name, "Decimal", null),
                "Double" => (_signedNumberTemplate.Value, name, "Double", null),
                "Float" => (_signedNumberTemplate.Value, name, "Float", "Single"),
                "Guid" => (_guidTemplate.Value, name, "Guid", null),
                "Half" => (_signedNumberTemplate.Value, name, "Half", null),
                "Int" => (_signedNumberTemplate.Value, name, "Int", "Int32"),
                "Long" => (_signedNumberTemplate.Value, name, "Long", "Int64"),
                "SByte" => (_signedNumberTemplate.Value, name, "SByte", "SByte"),
                "Short" => (_signedNumberTemplate.Value, name, "Short", "Int16"),
                "String" => (_stringTemplate.Value, name, "String", null),
                "UInt" => (_unsignedNumberTemplate.Value, name, "UInt", "UInt32"),
                "ULong" => (_unsignedNumberTemplate.Value, name, "ULong", "UInt64"),
                "UShort" => (_unsignedNumberTemplate.Value, name, "UShort", "UInt16"),
                "Bool" => (_boolTemplate.Value, name, "Bool", "Boolean"),
                _ => throw new Exception($"Unknown strict type: {recordDeclarationSyntax[i].type}"),
            };

            IEnumerable<StringBuilder> s = _generateStrictTypeFromTemplate(template, typeName, informalName, formalName).SplitLines().Select(o => new StringBuilder(o));
            foreach ((_, string parentDeclaration) in parents)
            {
                s = SyntaxNodeHelper.IndentAndWrap(s, parentDeclaration, "}");
            }

            s = SyntaxNodeHelper.Wrap(s, $"namespace {nameSpace};{Environment.NewLine}", string.Empty);
            s = SyntaxNodeHelper.Wrap(s, Resources.AutoGeneratedHeader, Resources.AutoGeneratedFooter);
            var content = s.Aggregate(new StringBuilder(), (acc, next) => acc.AppendLine(next.ToString())).ToString();
            cancellationToken.ThrowIfCancellationRequested();
            yield return (fileName: $"{recordDeclarationSyntax[i].type}-{nameSpace.Replace(".", "_")}_{string.Join("-", parents.Select(p => p.name).Aggregate(new Stack<string>(), (acc, next) => { acc.Push(next); return acc; }).Concat(new[] { name })).Replace(".", "_")}", content);
        }
    }

    private static string _generateStrictTypeFromTemplate(string template, string typeName, string informalTypeName, string? formalTypeName = null)
    {
        return template
            .Replace("STRICT_TYPE", typeName)
            .Replace("BASE_TYPE_INFORMAL_NAME", informalTypeName)
            .Replace("BASE_TYPE_FORMAL_NAME", formalTypeName ?? informalTypeName);
    }

    static class SyntaxNodeHelper
    {
        public static string GetNamespace(BaseTypeDeclarationSyntax syntax, CancellationToken cancellationToken)
        {
            StringBuilder nameSpace = default!;

            SyntaxNode? potentialNamespaceParent = syntax.Parent;

            while (potentialNamespaceParent != null &&
                    potentialNamespaceParent is not NamespaceDeclarationSyntax
                    && potentialNamespaceParent is not FileScopedNamespaceDeclarationSyntax
                    && !cancellationToken.IsCancellationRequested)
            {
                potentialNamespaceParent = potentialNamespaceParent.Parent;
            }

            if (potentialNamespaceParent is BaseNamespaceDeclarationSyntax namespaceParent)
            {
                nameSpace = new StringBuilder(namespaceParent.Name.ToString());

                while (namespaceParent.Parent is NamespaceDeclarationSyntax parent && !cancellationToken.IsCancellationRequested)
                {
                    nameSpace.Insert(0, ".");
                    nameSpace = nameSpace.Insert(0, namespaceParent.Name);
                    namespaceParent = parent;
                }
            }
            cancellationToken.ThrowIfCancellationRequested();

            return nameSpace.ToString();
        }

        public static IEnumerable<(string name, string declaration)> GetParentClasses(BaseTypeDeclarationSyntax typeSyntax, CancellationToken cancellationToken)
        {
            TypeDeclarationSyntax? parentSyntax = typeSyntax.Parent as TypeDeclarationSyntax;

            while (parentSyntax != null && _isAllowedKind(parentSyntax.Kind()) && !cancellationToken.IsCancellationRequested)
            {
                yield return (name: parentSyntax.Identifier.ToString(), declaration: $"{parentSyntax.Modifiers} {parentSyntax.Keyword} {parentSyntax.Identifier}{Environment.NewLine}{{");

                parentSyntax = (parentSyntax.Parent as TypeDeclarationSyntax);
            }
            cancellationToken.ThrowIfCancellationRequested();
        }

        // We can only be nested in class/struct/record
        static bool _isAllowedKind(SyntaxKind kind) =>
            kind == SyntaxKind.ClassDeclaration ||
            kind == SyntaxKind.StructDeclaration ||
            kind == SyntaxKind.RecordDeclaration;

        public static IEnumerable<StringBuilder> IndentAndWrap(IEnumerable<StringBuilder> s, string preWrap, string postWrap) =>
            Wrap(s.Select(Indent), preWrap, postWrap);

        public static IEnumerable<StringBuilder> Wrap(IEnumerable<StringBuilder> s, string preWrap, string postWrap) =>
            preWrap.SplitLines().Select(o => new StringBuilder(o)).Concat(s).Concat(postWrap.SplitLines().Select(o => new StringBuilder(o)));

        public static StringBuilder Indent(StringBuilder s) =>
            s.Length == 0 || s[0] == '#' ? s
            : s.Insert(0, "    ");
    }
}
