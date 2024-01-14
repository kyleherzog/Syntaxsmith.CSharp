using Syntaxsmith.CSharp.Interfaces;

namespace Syntaxsmith.CSharp.Configuration;

public abstract class ConfigurationBuilderBase
{
    internal abstract IConfigurationFormatter ConfigurationFormatter { get; }

    internal abstract bool ShouldIndentLines { get; }

    public void AppendToContext(SyntaxContext context)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var lines = ConfigurationFormatter.ToLines();
        context.AddLine(lines[0]);
        for (var i = 1; i < lines.Count; i++)
        {
            if (ShouldIndentLines)
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
