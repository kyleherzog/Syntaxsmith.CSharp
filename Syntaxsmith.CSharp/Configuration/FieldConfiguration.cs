using System.Text;
using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;
using Syntaxsmith.CSharp.Interfaces;

namespace Syntaxsmith.CSharp.Configuration;

internal class FieldConfiguration : IKeywordModifiable
{
    public FieldConfiguration(string type, string name)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(type));
        }

        name.ValidateAsObjectIdentifier();
        Name = name;
        Type = type;
    }

    public string Initializer { get; set; } = string.Empty;

    public KeywordModifiers Modifiers { get; set; }

    public string Name { get; }

    public string Type { get; }

    public VisibilityModifier? Visibility { get; set; }

    public override string ToString()
    {
        var line = new StringBuilder();

        line.AppendIf(Visibility is not null, Visibility?.ToKeywords(), " ");
        line.Append(Modifiers.ToCodeText());

        line.Append(Type);
        line.Append(' ');
        line.Append(Name);

        if (!string.IsNullOrWhiteSpace(Initializer))
        {
            line.Append(" = ");
            line.Append(Initializer.TrimEnd(';'));
        }

        line.Append(';');

        return line.ToString();
    }
}