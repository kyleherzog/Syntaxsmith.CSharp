using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Interfaces;

namespace Syntaxsmith.CSharp.Configuration;

public abstract class TypeConfigurationBuilder<T> : ConfigurationBuilderBase where T : TypeConfigurationBuilder<T>
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

    internal override IConfigurationFormatter ConfigurationFormatter => Configuration;

    public T Internal()
    {
        Configuration.Visibility = VisibilityModifier.Internal;
        return (T)this;
    }

    public T Public()
    {
        Configuration.Visibility = VisibilityModifier.Public;
        return (T)this;
    }

    public void AppendToContext(SyntaxContext context)
    {
        Configuration.AppendToContext(context);
    }
}