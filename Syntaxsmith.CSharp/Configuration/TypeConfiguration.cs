﻿using System.Text;
using System.Text.RegularExpressions;
using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;
using Syntaxsmith.CSharp.Interfaces;

namespace Syntaxsmith.CSharp.Configuration;

internal class TypeConfiguration : IConfigurationFormatter, IKeywordModifiable
{
    private const string validationPattern = @"^(?:[A-Z][a-zA-Z0-9]*)(?:<[A-Z][a-zA-Z0-9]*>)?$";

    public TypeConfiguration(string typeName, string typeKeyword)
    {
        if (typeName is null)
        {
            throw new ArgumentNullException(nameof(typeName));
        }

        if (typeKeyword is null)
        {
            throw new ArgumentNullException(nameof(typeKeyword));
        }

        var isValidName = Regex.IsMatch(typeName, validationPattern);

        if (!isValidName)
        {
            throw new ArgumentException($"The {typeKeyword} name '{typeName}' is invalid.", nameof(typeName));
        }

        TypeName = typeName;
        TypeKeyword = typeKeyword;
    }

    public Dictionary<string, IEnumerable<string>> GenericParameters { get; } = [];

    public string? Inherits { get; set; }

    public IEnumerable<string>? Interfaces { get; set; }

    public KeywordModifiers Modifiers { get; set; }

    public bool ShouldIndentChildLines => true;

    public string TypeKeyword { get; set; }

    public string TypeName { get; set; }

    public VisibilityModifier? Visibility { get; set; }

    public IList<string> ToLines()
    {
        var line = new StringBuilder();

        line.AppendIf(Visibility is not null, Visibility?.ToKeywords(), " ");
        line.Append(Modifiers.ToCodeText());

        line.Append(TypeKeyword);
        line.Append(' ');
        line.Append(TypeName);

        line.AppendIf(GenericParameters.Count > 0, "<", string.Join(", ", GenericParameters.Keys), ">");

        if (!string.IsNullOrWhiteSpace(Inherits) || (Interfaces?.Any() ?? false))
        {
            var implementations = new List<string>();
            if (!string.IsNullOrWhiteSpace(Inherits))
            {
                implementations.Add(Inherits!);
            }

            if (Interfaces?.Any() ?? false)
            {
                implementations.AddRange(Interfaces);
            }

            line.Append(" : ");
            line.Append(string.Join(", ", implementations));
        }

        var result = new List<string>
        {
            line.ToString()
        };

        var constrainedParameters = GenericParameters.Where(x => x.Value?.Any() ?? false);
        foreach (var constrainedParameter in constrainedParameters)
        {
            result.Add($"where {constrainedParameter.Key} : {string.Join(", ", constrainedParameter.Value)}");
        }

        return result;
    }
}