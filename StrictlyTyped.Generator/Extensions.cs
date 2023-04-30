﻿using System;
using System.Collections.Generic;
using System.Linq;
using StrictlyTyped.Generator.Properties;

namespace StrictlyTyped.Generator
{
    internal static class Extensions
    {
        private static IReadOnlyList<string> _indent(this IEnumerable<string> lines) =>
            lines.Select(line => $"    {line}").ToList().AsReadOnly();

        internal static IReadOnlyList<string> WrapInBlock(this IEnumerable<string> lines, string blockHeader)
        {
            List<string> result = new() { blockHeader, "{" };
            result.AddRange(lines._indent());
            result.Add("}");
            return result.AsReadOnly();
        }

        internal static IReadOnlyList<string> SplitLines(this string lines) =>
            lines.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList().AsReadOnly();

        internal static string Combine(this IEnumerable<string> lines) =>
            string.Join(Environment.NewLine, lines);

        internal static IReadOnlyList<string> AddHeaders(this IEnumerable<string> lines, params string[] otherHeaders)
        {
            var header = new List<string> { Resources.AutoGeneratedHeader };
            header.AddRange(otherHeaders);
            header.Add(string.Empty);
            header.AddRange(lines);
            header.Add(string.Empty);
            return header.ToList().AsReadOnly();
        }
    }
}
