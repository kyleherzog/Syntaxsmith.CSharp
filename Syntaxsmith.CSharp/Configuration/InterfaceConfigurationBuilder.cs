using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;

namespace Syntaxsmith.CSharp.Configuration;

public class InterfaceConfigurationBuilder : TypeConfigurationBuilder<InterfaceConfigurationBuilder>
{
    public InterfaceConfigurationBuilder(string interfaceName)
        : base(interfaceName, "interface")
    {
        GlobalConfiguration.Interface?.Invoke(this);
    }

    public InterfaceConfigurationBuilder Body (Action<CSharpCodeBuilder> body)
    {
        Configuration.Body = body;
        return this;
    }

    public InterfaceConfigurationBuilder Inherits(params string[] interfaces)
    {
        Configuration.Interfaces = interfaces;
        return this;
    }

    public InterfaceConfigurationBuilder Inherits<T>()
    {
        return Inherits(typeof(T).FriendlyName());
    }

    public InterfaceConfigurationBuilder Inherits(params Type[] interfaces)
    {
        return Inherits(interfaces.Select(x => x.FriendlyName()).ToArray());
    }

    public InterfaceConfigurationBuilder Partial(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Partial, isOn);
        return this;
    }

    public InterfaceConfigurationBuilder Private()
    {
        Configuration.Visibility = VisibilityModifier.Private;
        return this;
    }

    public InterfaceConfigurationBuilder Protected()
    {
        Configuration.Visibility = VisibilityModifier.Protected;
        return this;
    }

    public InterfaceConfigurationBuilder ProtectedInternal()
    {
        Configuration.Visibility = VisibilityModifier.ProtectedInternal;
        return this;
    }

    public InterfaceConfigurationBuilder WithGenericParameter(string parameterName, params string[] constraints)
    {
        Configuration.GenericParameters[parameterName] = constraints;
        return this;
    }
}