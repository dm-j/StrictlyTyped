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

    private (RecordDeclarationSyntax? record, string type) _getSemanticTargetForGeneration(GeneratorSyntaxContext context)
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

    private static readonly Lazy<string[]> _boolTemplate = new(() => Resources.StrictBoolTemplate.Split(new[] { "ZYX" }, StringSplitOptions.None));
    private static readonly Lazy<string[]> _byteTemplate = new(() => Resources.StrictByteTemplate.Split(new[] { "ZYX" }, StringSplitOptions.None));
    private static readonly Lazy<string[]> _decimalTemplate = new(() => Resources.StrictDecimalTemplate.Split(new[] { "ZYX" }, StringSplitOptions.None));
    private static readonly Lazy<string[]> _doubleTemplate = new(() => Resources.StrictDoubleTemplate.Split(new[] { "ZYX" }, StringSplitOptions.None));
    private static readonly Lazy<string[]> _floatTemplate = new(() => Resources.StrictFloatTemplate.Split(new[] { "ZYX" }, StringSplitOptions.None));
    private static readonly Lazy<string[]> _guidTemplate = new(() => Resources.StrictGuidTemplate.Split(new[] { "ZYX" }, StringSplitOptions.None));
    private static readonly Lazy<string[]> _halfTemplate = new(() => Resources.StrictHalfTemplate.Split(new[] { "ZYX" }, StringSplitOptions.None));
    private static readonly Lazy<string[]> _intTemplate = new(() => Resources.StrictIntTemplate.Split(new[] { "ZYX" }, StringSplitOptions.None));
    private static readonly Lazy<string[]> _longTemplate = new(() => Resources.StrictLongTemplate.Split(new[] { "ZYX" }, StringSplitOptions.None));
    private static readonly Lazy<string[]> _sbyteTemplate = new(() => Resources.StrictSByteTemplate.Split(new[] { "ZYX" }, StringSplitOptions.None));
    private static readonly Lazy<string[]> _shortTemplate = new(() => Resources.StrictShortTemplate.Split(new[] { "ZYX" }, StringSplitOptions.None));
    private static readonly Lazy<string[]> _stringTemplate = new(() => Resources.StrictStringTemplate.Split(new[] { "ZYX" }, StringSplitOptions.None));
    private static readonly Lazy<string[]> _uIntTemplate = new(() => Resources.StrictUIntTemplate.Split(new[] { "ZYX" }, StringSplitOptions.None));
    private static readonly Lazy<string[]> _uLongTemplate = new(() => Resources.StrictULongTemplate.Split(new[] { "ZYX" }, StringSplitOptions.None));
    private static readonly Lazy<string[]> _uShortTemplate = new(() => Resources.StrictUShortTemplate.Split(new[] { "ZYX" }, StringSplitOptions.None));

    private static IEnumerable<(string fileName, string content)> _generateRecords(Compilation compilation, IEnumerable<(RecordDeclarationSyntax record, string type)> distinctRecords, CancellationToken cancellationToken)
    {
        var recordDeclarationSyntax = distinctRecords.ToArray();
        for (int i = 0; i < recordDeclarationSyntax.Count(); i++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            SemanticModel semanticModel = compilation.GetSemanticModel(recordDeclarationSyntax[i].record.SyntaxTree);
            if (semanticModel.GetDeclaredSymbol(recordDeclarationSyntax[i].record) is not INamedTypeSymbol recordSymbol)
            {
                continue;
            }
            string recordName = recordSymbol.ToString();
            string name = recordSymbol.Name;
            string nameSpace = SyntaxNodeHelper.GetNamespace(recordDeclarationSyntax[i].record);
            var parents = SyntaxNodeHelper.GetParentClasses(recordDeclarationSyntax[i].record);

            string[] template = recordDeclarationSyntax[i].type switch
            {
                "Byte" => _byteTemplate.Value,
                "Decimal" => _decimalTemplate.Value,
                "Double" => _doubleTemplate.Value,
                "Float" => _floatTemplate.Value,
                "Guid" => _guidTemplate.Value,
                "Half" => _halfTemplate.Value,
                "Int" => _intTemplate.Value,
                "Long" => _longTemplate.Value,
                "SByte" => _sbyteTemplate.Value,
                "Short" => _shortTemplate.Value,
                "String" => _stringTemplate.Value,
                "UInt" => _uIntTemplate.Value,
                "ULong" => _uLongTemplate.Value,
                "UShort" => _uShortTemplate.Value,
                "Bool" => _boolTemplate.Value,
                _ => throw new Exception($"Unknown strict type: {recordDeclarationSyntax[i].type}"),
            };

            IEnumerable<StringBuilder> s = string.Join(name, template).SplitLines().Select(o => new StringBuilder(o));
            foreach ((_, string parentDeclaration) in parents)
            {
                s = SyntaxNodeHelper.IndentAndWrap(s, parentDeclaration, "}");
            }

            s = SyntaxNodeHelper.Wrap(s, $"namespace {nameSpace};{Environment.NewLine}", string.Empty);
            s = SyntaxNodeHelper.Wrap(s, Resources.AutoGeneratedHeader, Resources.AutoGeneratedFooter);
            var content = s.Aggregate(new StringBuilder(), (acc, next) => acc.AppendLine(next.ToString())).ToString();

            yield return (fileName: $"{recordDeclarationSyntax[i].type}-{nameSpace.Replace(".", "_")}_{string.Join("-", parents.Select(p => p.name).Aggregate(new Stack<string>(), (acc, next) => { acc.Push(next); return acc; }).Concat(new[] { name })).Replace(".", "_")}", content);
        }
    }

    static class SyntaxNodeHelper
    {
        public static string GetNamespace(BaseTypeDeclarationSyntax syntax)
        {
            StringBuilder nameSpace = default!;

            SyntaxNode? potentialNamespaceParent = syntax.Parent;

            while (potentialNamespaceParent != null &&
                    potentialNamespaceParent is not NamespaceDeclarationSyntax
                    && potentialNamespaceParent is not FileScopedNamespaceDeclarationSyntax)
            {
                potentialNamespaceParent = potentialNamespaceParent.Parent;
            }

            if (potentialNamespaceParent is BaseNamespaceDeclarationSyntax namespaceParent)
            {
                nameSpace = new StringBuilder(namespaceParent.Name.ToString());

                while (namespaceParent.Parent is NamespaceDeclarationSyntax parent)
                {
                    nameSpace.Insert(0, ".");
                    nameSpace = nameSpace.Insert(0, namespaceParent.Name);
                    namespaceParent = parent;
                }
            }

            return nameSpace.ToString();
        }

        public static IEnumerable<(string name, string declaration)> GetParentClasses(BaseTypeDeclarationSyntax typeSyntax)
        {
            TypeDeclarationSyntax? parentSyntax = typeSyntax.Parent as TypeDeclarationSyntax;

            while (parentSyntax != null && _isAllowedKind(parentSyntax.Kind()))
            {
                yield return (name: parentSyntax.Identifier.ToString(), declaration: $"{parentSyntax.Modifiers} {parentSyntax.Keyword} {parentSyntax.Identifier}{Environment.NewLine}{{");

                parentSyntax = (parentSyntax.Parent as TypeDeclarationSyntax);
            }

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
            : s.Insert(0, "  ");
    }
}
