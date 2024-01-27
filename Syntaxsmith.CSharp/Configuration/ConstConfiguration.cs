
using System.Text;
using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;

namespace Syntaxsmith.CSharp.Configuration;

internal class ConstConfiguration
{
    public ConstConfiguration(string type, string name, object? value)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(type));
        }

        name.ValidateAsObjectIdentifier();
        Name = name;
        Type = type;
        Value = value;
    }

    public string Name { get; }
    public string Type { get; }

    public object? Value { get; set; }

    public VisibilityModifier? Visibility { get; set; }

    public override string ToString()
    {
        var line = new StringBuilder();

        line.AppendIf(Visibility is not null, Visibility?.ToKeywords(), " ");

        line.Append("const ");

        line.Append(Type);
        line.Append(' ');
        line.Append(Name);
        line.Append(" = ");

        if (Value is null)
        {
            line.Append("null");
        }
        else if (Value is string stringValue)
        {
            line.Append('"');
            line.Append(stringValue);
            line.Append('"');
        }
        else
        {
            line.Append(Value.ToString().ToLowerInvariant());
        }

        line.Append(';');

        return line.ToString();
    }
}
