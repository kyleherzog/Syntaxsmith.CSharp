using System.Text;
using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;
using Syntaxsmith.CSharp.Interfaces;

namespace Syntaxsmith.CSharp.Configuration;

internal class TypeConfiguration : IKeywordModifiable
{
    public TypeConfiguration(string typeName, string typeKeyword)
    {
        typeName.ValidateAsObjectIdentifier();

        if (typeKeyword is null)
        {
            throw new ArgumentNullException(nameof(typeKeyword));
        }

        TypeName = typeName;
        TypeKeyword = typeKeyword;
    }

    public Action<CSharpCodeBuilder> Body { get; set; }

    public Dictionary<string, IEnumerable<string>> GenericParameters { get; } = [];

    public string? Inherits { get; set; }

    public IEnumerable<string>? Interfaces { get; set; }

    public KeywordModifiers Modifiers { get; set; }

    public string TypeKeyword { get; set; }

    public string TypeName { get; set; }

    public VisibilityModifier? Visibility { get; set; }

    public void AppendToContext(SyntaxContext context)
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

        var codeBuilder = new CSharpCodeBuilder(context);
        codeBuilder.AddLine(line.ToString());

        var constrainedParameters = GenericParameters.Where(x => x.Value?.Any() ?? false);
        foreach (var constrainedParameter in constrainedParameters)
        {
            codeBuilder.AddChildLine($"where {constrainedParameter.Key} : {string.Join(", ", constrainedParameter.Value)}");
        }

        if (Body is not null)
        {
            codeBuilder.OpenBlock();
            Body.Invoke(codeBuilder);
            codeBuilder.CloseBlock();
        }
    }
}