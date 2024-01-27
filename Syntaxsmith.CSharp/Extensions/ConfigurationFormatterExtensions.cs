using Syntaxsmith.CSharp.Interfaces;

namespace Syntaxsmith.CSharp;

internal static class ConfigurationFormatterExtensions
{
    public static void AppendToContext(this IConfigurationFormatter formatter, SyntaxContext context)
    {
        if (formatter is null)
        {
            throw new ArgumentNullException(nameof(formatter));
        }

        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var lines = formatter.ToLines();
        context.AddLine(lines[0]);
        for (var i = 1; i < lines.Count; i++)
        {
            if (formatter.ShouldIndentChildLines)
            {
                context.AddChildLine(lines[i]);
            }
            else
            {
                context.AddLine(lines[i]);
            }
        }
    }
}