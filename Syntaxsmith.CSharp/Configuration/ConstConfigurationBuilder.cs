using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;

namespace Syntaxsmith.CSharp.Configuration;

public class ConstConfigurationBuilder
{
    public ConstConfigurationBuilder(string type, string name, object? value)
    {
        Configuration = new ConstConfiguration(type, name, value);
    }

    internal ConstConfiguration Configuration { get; }

    public void AppendToContext(SyntaxContext context)
    {
        context.AddLine(Configuration.ToString());
    }

    public ConstConfigurationBuilder Internal()
    {
        Configuration.Visibility = VisibilityModifier.Internal;
        return this;
    }

    public ConstConfigurationBuilder Private()
    {
        Configuration.Visibility = VisibilityModifier.Private;
        return this;
    }

    public ConstConfigurationBuilder Public()
    {
        Configuration.Visibility = VisibilityModifier.Public;
        return this;
    }

    public static ConstConfigurationBuilder Create<T>(string name, T value)
    {
        return new(typeof(T).FriendlyName(), name, value);
    }
}