using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;

namespace Syntaxsmith.CSharp.Configuration;

public class MethodConfigurationBuilder
{
    public MethodConfigurationBuilder(string name)
    {
        Configuration = new MethodConfiguration(name);
        GlobalConfiguration.Method?.Invoke(this);
    }

    internal MethodConfiguration Configuration { get; }

    public MethodConfigurationBuilder Abstract(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Abstract, isOn);
        return this;
    }

    public MethodConfigurationBuilder AddParameter(string type, string name, Action<ParameterConfigurationBuilder>? configAction = null)
    {
        var builder = new ParameterConfigurationBuilder(type, name);
        configAction?.Invoke(builder);
        Configuration.ParameterBuilders.Add(builder);
        return this;
    }

    public MethodConfigurationBuilder AddParameter<T>(string name, Action<ParameterConfigurationBuilder>? configAction = null)
    {
        return AddParameter(typeof(T).FriendlyName(), name);
    }

    public void AppendToContext(SyntaxContext context)
    {
        Configuration.AppendToContext(context);
    }

    public MethodConfigurationBuilder Async(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Async, isOn);
        return this;
    }

    public MethodConfigurationBuilder Body(Action<CSharpCodeBuilder> body)
    {
        Configuration.Body = body;
        return this;
    }

    public MethodConfigurationBuilder Extern(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Extern, isOn);
        return this;
    }

    public MethodConfigurationBuilder Internal()
    {
        Configuration.Visibility = VisibilityModifier.Internal;
        return this;
    }

    public MethodConfigurationBuilder New(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.New, isOn);
        return this;
    }

    public MethodConfigurationBuilder Override(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Override, isOn);
        return this;
    }

    public MethodConfigurationBuilder Partial(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Partial, isOn);
        return this;
    }

    public MethodConfigurationBuilder Private()
    {
        Configuration.Visibility = VisibilityModifier.Private;
        return this;
    }

    public MethodConfigurationBuilder Protected()
    {
        Configuration.Visibility = VisibilityModifier.Protected;
        return this;
    }

    public MethodConfigurationBuilder ProtectedInternal()
    {
        Configuration.Visibility = VisibilityModifier.ProtectedInternal;
        return this;
    }

    public MethodConfigurationBuilder Public()
    {
        Configuration.Visibility = VisibilityModifier.Public;
        return this;
    }

    public MethodConfigurationBuilder Returning<T>()
    {
        var type = typeof(T);
        return Returning(type.FriendlyName());
    }

    public MethodConfigurationBuilder Returning(string type)
    {
        Configuration.ReturnType = type;
        return this;
    }

    public MethodConfigurationBuilder Sealed(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Sealed, isOn);
        return this;
    }

    public MethodConfigurationBuilder Static(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Static, isOn);
        return this;
    }

    public MethodConfigurationBuilder Unsafe(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Unsafe, isOn);
        return this;
    }

    public MethodConfigurationBuilder Virtual(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Virtual, isOn);
        return this;
    }

    public MethodConfigurationBuilder WithGenericParameter(string parameterName, params string[] constraints)
    {
        Configuration.GenericParameters[parameterName] = constraints;
        return this;
    }
}