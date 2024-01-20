using Syntaxsmith.CSharp.Enums;

namespace Syntaxsmith.CSharp.Configuration;

public class InterfaceConfigurationBuilder : TypeConfigurationBuilder<InterfaceConfigurationBuilder>
{
    public InterfaceConfigurationBuilder(string interfaceName)
        : base(interfaceName, "interface")
    {
        GlobalConfiguration.Interface?.Invoke(this);
    }

    public InterfaceConfigurationBuilder Inherits(params string[] interfaces)
    {
        Configuration.Interfaces = interfaces;
        return this;
    }

    public InterfaceConfigurationBuilder Inherits<T>()
    {
        return Inherits(typeof(T).Name);
    }

    public InterfaceConfigurationBuilder Inherits(params Type[] interfaces)
    {
        return Inherits(interfaces.Select(x => x.Name).ToArray());
    }

    public InterfaceConfigurationBuilder Partial(bool isOn = true)
    {
        Configuration.ToggleModifier(TypeModifiers.Partial, isOn);
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