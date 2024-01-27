using System.Text;
using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;
using Syntaxsmith.CSharp.Interfaces;

namespace Syntaxsmith.CSharp.Configuration;

internal class MethodConfiguration : IConfigurationFormatter, IKeywordModifiable
{
    public MethodConfiguration(string name)
    {
        name.ValidateAsObjectIdentifier();
        Name = name;
    }

    public KeywordModifiers Modifiers { get; set; }

    public string Name { get; }

    public Dictionary<string, IEnumerable<string>> GenericParameters { get; } = [];

    public List<ParameterConfigurationBuilder> ParameterBuilders { get; set; } = [];

    public string? ReturnType { get; set; }

    public bool ShouldIndentChildLines => true;

    public VisibilityModifier? Visibility { get; set; }

    public IList<string> ToLines()
    {
        var line = new StringBuilder();

        line.AppendIf(Visibility is not null, Visibility?.ToKeywords(), " ");
        line.Append(Modifiers.ToCodeText());

        line.Append(string.IsNullOrEmpty(ReturnType) ? "void" : ReturnType);
        line.Append(' ');
        line.Append(Name);
        line.AppendIf(GenericParameters.Count > 0, "<", string.Join(", ", GenericParameters.Keys), ">");


        line.Append('(');

        for (var i = 0; i < ParameterBuilders.Count; i++)
        {
            if (i > 0)
            {
                line.Append(", ");
            }

            line.Append(ParameterBuilders[i].ToString());
        }

        line.Append(')');

        var result = new List<string>();

        var isSelfClosing = Modifiers.HasFlag(KeywordModifiers.Abstract);

        var constrainedParameters = GenericParameters.Where(x => x.Value?.Any() ?? false).ToList();
        if (constrainedParameters.Count > 0)
        {
            result.Add(line.ToString());

            for (var i = 0; i < constrainedParameters.Count; i++)
            {
                var constrainedParameter = constrainedParameters[i];
                result.Add($"where {constrainedParameter.Key} : {string.Join(", ", constrainedParameter.Value)}{(isSelfClosing && i == constrainedParameters.Count - 1 ? ";" : string.Empty)}");
            }
        }
        else
        {
            if (isSelfClosing)
            {
                line.Append(';');
            }
            result.Add(line.ToString());
        }

        return result;
    }
}