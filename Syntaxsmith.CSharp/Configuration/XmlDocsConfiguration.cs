using System.Text;

namespace Syntaxsmith.CSharp.Configuration;

internal class XmlDocsConfiguration
{
    public IList<(string Type, string Description)> Exceptions { get; } = [];

    public bool IsInherit { get; set; }

    public IList<(string Name, string Description)> Parameters { get; } = [];

    public string? Returns { get; set; }

    public string? Summary { get; set; }

    public void AppendToContext(SyntaxContext context)
    {
        if (IsInherit)
        {
            context.AddLine(DocLine("<inheritdoc/>"));
            return;
        }

        AddTag(context, Summary, "summary");
        foreach (var parameter in Parameters)
        {
            AddTag(context, parameter.Description, "param", ("name", parameter.Name));
        }
        AddTag(context, Returns, "returns");

        foreach (var exception in Exceptions)
        {
            AddTag(context, exception.Description, "exception", ("cref", exception.Type));
        }
    }

    private static void AddTag(SyntaxContext context, string? value, string tag, params (string Key, string Value)[] parameters)
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

        context.AddLine(openTagBuilder.ToString());
        context.AddLine(DocLine(value!));
        context.AddLine(DocLine($"</{tag}>"));
    }

    private static string DocLine(string line)
    {
        return $"/// {line}";
    }
}