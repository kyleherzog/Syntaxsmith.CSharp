using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;

namespace Syntaxsmith.CSharp.Configuration;

public class FieldConfigurationBuilder
{
    public FieldConfigurationBuilder(string type, string name)
    {
        Configuration = new FieldConfiguration(type, name);
        GlobalConfiguration.Field?.Invoke(this);
    }

    internal FieldConfiguration Configuration { get; }

    public static FieldConfigurationBuilder Create<T>(string name)
    {
        var type = typeof(T);
        return new FieldConfigurationBuilder(type.FriendlyName(), name);
    }

    public void AppendToContext(SyntaxContext context)
    {
        context.AddLine(Configuration.ToString());
    }

    public FieldConfigurationBuilder InitializeStringTo(string value)
    {
        Configuration.Initializer = $"\"{value}\"";
        return this;
    }

    public FieldConfigurationBuilder InitializeTo(string initializer)
    {
        Configuration.Initializer = initializer;
        return this;
    }

    public FieldConfigurationBuilder Internal()
    {
        Configuration.Visibility = VisibilityModifier.Internal;
        return this;
    }

    public FieldConfigurationBuilder Private()
    {
        Configuration.Visibility = VisibilityModifier.Private;
        return this;
    }

    public FieldConfigurationBuilder Protected()
    {
        Configuration.Visibility = VisibilityModifier.Protected;
        return this;
    }

    public FieldConfigurationBuilder ProtectedInternal()
    {
        Configuration.Visibility = VisibilityModifier.ProtectedInternal;
        return this;
    }

    public FieldConfigurationBuilder Public()
    {
        Configuration.Visibility = VisibilityModifier.Public;
        return this;
    }

    public FieldConfigurationBuilder Readonly(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Readonly, isOn);
        return this;
    }

    public FieldConfigurationBuilder Static(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Static, isOn);
        return this;
    }

    public FieldConfigurationBuilder Unsafe(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Unsafe, isOn);
        return this;
    }

    public FieldConfigurationBuilder Volatile(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Volatile, isOn);
        return this;
    }
}