using System.Text;
using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;
using Syntaxsmith.CSharp.Interfaces;

namespace Syntaxsmith.CSharp.Configuration;

internal class PropertyConfiguration : IKeywordModifiable
{
    public PropertyConfiguration(string type, string name)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(type));
        }

        name.ValidateAsObjectIdentifier();
        Name = name;
        Type = type;
    }

    public Action<CSharpCodeBuilder>? Getter { get; set; }

    public VisibilityModifier? GetterVisibility { get; set; }

    public string Initializer { get; set; } = string.Empty;

    public bool IsReadOnly { get; set; }

    public KeywordModifiers Modifiers { get; set; }

    public string Name { get; }

    public Action<CSharpCodeBuilder>? Setter { get; set; }

    public VisibilityModifier? SetterVisibility { get; set; }

    public string Type { get; }

    public VisibilityModifier? Visibility { get; set; }

    public void AppendToContext(SyntaxContext context)
    {
        var codeBuilder = new CSharpCodeBuilder(context);
        var builder = new StringBuilder();
        builder.AppendIf(Visibility is not null, Visibility?.ToKeywords(), " ");
        builder.Append(Modifiers.ToCodeText());

        builder.Append(Type);
        builder.Append(' ');
        builder.Append(Name);

        if (Getter is null && Setter is null)
        {
            builder.Append(" { ");
            builder.Append(GetterKeywordWithVisibility());
            builder.Append("; ");
            builder.AppendIf(!IsReadOnly, SetterKeywordWithVisibility(), "; ");
            builder.Append('}');

            if (!string.IsNullOrWhiteSpace(Initializer))
            {
                builder.Append(" = ");
                builder.Append(Initializer.TrimEnd(';'));
                builder.Append(';');
            }

            codeBuilder.AddLine(builder.ToString());
        }
        else
        {
            codeBuilder.AddLine(builder.ToString());
            codeBuilder.OpenBlock();

            if (Getter is not null)
            {
                codeBuilder.AddLine(GetterKeywordWithVisibility());
                codeBuilder.OpenBlock();
                Getter.Invoke(new CSharpCodeBuilder(codeBuilder.Context));
                codeBuilder.CloseBlock();
            }
            if (Setter is not null)
            {
                codeBuilder.AddLine(SetterKeywordWithVisibility());

                codeBuilder.OpenBlock();
                Setter.Invoke(new CSharpCodeBuilder(codeBuilder.Context));
                codeBuilder.CloseBlock();
            }
            codeBuilder.CloseBlock();
        }
    }

    private string GetterKeywordWithVisibility()
    {
        var builder = new StringBuilder();
        builder.AppendIf(GetterVisibility is not null, GetterVisibility?.ToKeywords(), " ");
        builder.Append("get");
        return builder.ToString();
    }

    private string SetterKeywordWithVisibility()
    {
        var builder = new StringBuilder();
        builder.AppendIf(SetterVisibility is not null, SetterVisibility?.ToKeywords(), " ");
        builder.Append("set");
        return builder.ToString();
    }
}