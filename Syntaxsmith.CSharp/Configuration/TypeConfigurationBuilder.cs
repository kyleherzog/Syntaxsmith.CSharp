using Syntaxsmith.CSharp.Enums;

namespace Syntaxsmith.CSharp.Configuration;

public abstract class TypeConfigurationBuilder<T> where T : TypeConfigurationBuilder<T>
{
    protected TypeConfigurationBuilder(string typeName, string typeKeyword)
    {
        if (typeName is null)
        {
            throw new ArgumentNullException(nameof(typeName));
        }

        Configuration = new TypeConfiguration(typeName, typeKeyword);
    }

    internal TypeConfiguration Configuration { get; }

    public void AppendToContext(SyntaxContext context)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var lines = Configuration.ToLines();
        context.AddLine(lines[0]);
        for (var i = 1; i < lines.Count; i++)
        {
            context.AddChildLine(lines[i]);
        }
    }

    public T Public()
    {
        Configuration.Visibility = VisibilityModifier.Public;
        return (T)this;
    }

    public T Internal()
    {
        Configuration.Visibility = VisibilityModifier.Internal;
        return (T)this;
    }
}