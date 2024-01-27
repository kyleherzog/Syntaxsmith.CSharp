using System.Text;
using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;

namespace Syntaxsmith.CSharp.Configuration;

internal class ParameterConfiguration
{
    public ParameterConfiguration(string type, string name)
    {
        name.ValidateAsObjectIdentifier();
        Name = name;
        Type = type;
    }

    public ParameterKeyword Keyword { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }

    public override string ToString()
    {
        var builder = new StringBuilder();

        if (Keyword != ParameterKeyword.None)
        {
            builder.Append(Keyword.ToString().ToLowerInvariant());
            builder.Append(' ');
        }

        builder.Append(Type);
        builder.Append(' ');
        builder.Append(Name);

        return builder.ToString();
    }
}