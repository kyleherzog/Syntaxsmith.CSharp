using System.Text;
using System.Text.RegularExpressions;
using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;

namespace Syntaxsmith.CSharp.Configuration;

internal class TypeConfiguration
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

    public IDictionary<string, IEnumerable<string>> GenericParameters { get; } = new Dictionary<string, IEnumerable<string>>();

    public string? Inherits { get; set; }

    public IEnumerable<string>? Interfaces { get; set; }

    public TypeModifiers Modifiers { get; set; }

    public string TypeKeyword { get; set; }

    public string TypeName { get; set; }

    public VisibilityModifier? Visibility { get; set; }

    public void ToggleModifier(TypeModifiers modifier, bool isOn)
    {
        if (isOn)
        {
            Modifiers |= modifier;
        }
        else
        {
            Modifiers &= ~modifier;
        }
    }

    public IList<string> ToLines()
    {
        var line = new StringBuilder();

        line.AppendIf(Visibility is not null, Visibility.ToString().ToLowerInvariant(), " ");
        line.Append(Modifiers.ToKeywords());

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