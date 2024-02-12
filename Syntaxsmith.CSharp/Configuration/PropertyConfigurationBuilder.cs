using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;

namespace Syntaxsmith.CSharp.Configuration;

public class PropertyConfigurationBuilder
{
    public PropertyConfigurationBuilder(string type, string name)
    {
        Configuration = new PropertyConfiguration(type, name);
        GlobalConfiguration.Property?.Invoke(this);
    }

    internal PropertyConfiguration Configuration { get; }

    public static PropertyConfigurationBuilder Create<T>(string name)
    {
        var type = typeof(T);
        return new PropertyConfigurationBuilder(type.FriendlyName(), name);
    }

    public PropertyConfigurationBuilder Abstract(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Abstract, isOn);
        return this;
    }

    public void AppendToContext(SyntaxContext context)
    {
        Configuration.AppendToContext(context);
    }

    public PropertyConfigurationBuilder Getter(Action<CSharpCodeBuilder> getter)
    {
        Configuration.Getter = getter;
        return this;
    }

    public PropertyConfigurationBuilder InitializeStringTo(string value)
    {
        Configuration.Initializer = $"\"{value}\"";
        return this;
    }

    public PropertyConfigurationBuilder InitializeTo(string initializer)
    {
        Configuration.Initializer = initializer;
        return this;
    }

    public PropertyConfigurationBuilder Internal()
    {
        Configuration.Visibility = VisibilityModifier.Internal;
        return this;
    }

    public PropertyConfigurationBuilder InternalGetter(Action<CSharpCodeBuilder> getter)
    {
        Configuration.GetterVisibility = VisibilityModifier.Internal;
        Configuration.Getter = getter;
        return this;
    }

    public PropertyConfigurationBuilder InternalSetter(Action<CSharpCodeBuilder> setter)
    {
        Configuration.SetterVisibility = VisibilityModifier.Internal;
        Configuration.Setter = setter;
        return this;
    }

    public PropertyConfigurationBuilder Override(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Override, isOn);
        return this;
    }

    public PropertyConfigurationBuilder Private()
    {
        Configuration.Visibility = VisibilityModifier.Private;
        return this;
    }

    public PropertyConfigurationBuilder PrivateGetter(Action<CSharpCodeBuilder> getter)
    {
        Configuration.GetterVisibility = VisibilityModifier.Private;
        Configuration.Getter = getter;
        return this;
    }

    public PropertyConfigurationBuilder PrivateSetter(Action<CSharpCodeBuilder> setter)
    {
        Configuration.SetterVisibility = VisibilityModifier.Private;
        Configuration.Setter = setter;
        return this;
    }

    public PropertyConfigurationBuilder Protected()
    {
        Configuration.Visibility = VisibilityModifier.Protected;
        return this;
    }

    public PropertyConfigurationBuilder ProtectedGetter(Action<CSharpCodeBuilder> getter)
    {
        Configuration.GetterVisibility = VisibilityModifier.Protected;
        Configuration.Getter = getter;
        return this;
    }

    public PropertyConfigurationBuilder ProtectedInternal()
    {
        Configuration.Visibility = VisibilityModifier.ProtectedInternal;
        return this;
    }

    public PropertyConfigurationBuilder ProtectedInternalGetter(Action<CSharpCodeBuilder> getter)
    {
        Configuration.GetterVisibility = VisibilityModifier.ProtectedInternal;
        Configuration.Getter = getter;
        return this;
    }

    public PropertyConfigurationBuilder ProtectedInternalSetter(Action<CSharpCodeBuilder> setter)
    {
        Configuration.SetterVisibility = VisibilityModifier.ProtectedInternal;
        Configuration.Setter = setter;
        return this;
    }

    public PropertyConfigurationBuilder ProtectedSetter(Action<CSharpCodeBuilder> setter)
    {
        Configuration.SetterVisibility = VisibilityModifier.Protected;
        Configuration.Setter = setter;
        return this;
    }

    public PropertyConfigurationBuilder Public()
    {
        Configuration.Visibility = VisibilityModifier.Public;
        return this;
    }

    public PropertyConfigurationBuilder PublicGetter(Action<CSharpCodeBuilder> getter)
    {
        Configuration.GetterVisibility = VisibilityModifier.Public;
        Configuration.Getter = getter;
        return this;
    }

    public PropertyConfigurationBuilder PublicSetter(Action<CSharpCodeBuilder> setter)
    {
        Configuration.SetterVisibility = VisibilityModifier.Public;
        Configuration.Setter = setter;
        return this;
    }

    public PropertyConfigurationBuilder ReadOnly(bool isOn = true)
    {
        Configuration.IsReadOnly = isOn;
        return this;
    }

    public PropertyConfigurationBuilder Sealed(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Sealed, isOn);
        return this;
    }

    public PropertyConfigurationBuilder Setter(Action<CSharpCodeBuilder> setter)
    {
        Configuration.Setter = setter;
        return this;
    }

    public PropertyConfigurationBuilder Static(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Static, isOn);
        return this;
    }

    public PropertyConfigurationBuilder Unsafe(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Unsafe, isOn);
        return this;
    }

    public PropertyConfigurationBuilder Virtual(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Virtual, isOn);
        return this;
    }
}