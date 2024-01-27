using System.Text;
using Syntaxsmith.CSharp.Interfaces;

namespace Syntaxsmith.CSharp.Configuration;

internal class XmlDocsConfiguration : IConfigurationFormatter
{
    public IList<(string Type, string Description)> Exceptions { get; } = [];

    public bool IsInherit { get; set; }

    public IList<(string Name, string Description)> Parameters { get; } = [];

    public string? Returns { get; set; }

    public bool ShouldIndentChildLines => false;

    public string? Summary { get; set; }

    public IList<string> ToLines()
    {
        var results = new List<string>();

        if (IsInherit)
        {
            results.Add(DocLine("<inheritdoc/>"));
            return results;
        }

        AddTag(results, Summary, "summary");
        foreach (var parameter in Parameters)
        {
            AddTag(results, parameter.Description, "param", ("name", parameter.Name));
        }
        AddTag(results, Returns, "returns");

        foreach (var exception in Exceptions)
        {
            AddTag(results, exception.Description, "exception", ("cref", exception.Type));
        }

        return results;
    }

    private static void AddTag(IList<string> lines, string? value, string tag, params (string Key, string Value)[] parameters)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return;
        }

        var openTagBuilder = new StringBuilder(DocLine($"<{tag}"));
        foreach (var parameter in parameters)
        {
            openTagBuilder.Append(' ')
                .Append(parameter.Key)
                .Append("=\"")
                .Append(parameter.Value)
                .Append("\"");
        }
        openTagBuilder.Append('>');

        lines.Add(openTagBuilder.ToString());
        lines.Add(DocLine(value!));
        lines.Add(DocLine($"</{tag}>"));
    }

    private static string DocLine(string line)
    {
        return $"/// {line}";
    }
}