using Syntaxsmith.CSharp.Enums;

namespace Syntaxsmith.CSharp.Configuration;

public class StructConfigurationBuilder : TypeConfigurationBuilder<StructConfigurationBuilder>
{
    public StructConfigurationBuilder(string structName)
        : base(structName, "struct")
    {
    }

    public StructConfigurationBuilder Abstract(bool isOn = true)
    {
        Configuration.ToggleModifier(TypeModifiers.Abstract, isOn);
        return this;
    }

    public StructConfigurationBuilder Implements(params string[] interfaces)
    {
        Configuration.Interfaces = interfaces;
        return this;
    }

    public StructConfigurationBuilder Implements<T>()
    {
        return Implements(typeof(T).Name);
    }

    public StructConfigurationBuilder Implements(params Type[] interfaces)
    {
        return Implements(interfaces.Select(x => x.Name).ToArray());
    }

    public StructConfigurationBuilder Inherits(string baseClass)
    {
        Configuration.Inherits = baseClass;
        return this;
    }

    public StructConfigurationBuilder Inherits<T>()
    {
        return Inherits(typeof(T));
    }

    public StructConfigurationBuilder Inherits(Type baseType)
    {
        if (baseType is null)
        {
            throw new ArgumentNullException(nameof(baseType));
        }

        return Inherits(baseType.Name);
    }

    public StructConfigurationBuilder Partial(bool isOn = true)
    {
        Configuration.ToggleModifier(TypeModifiers.Partial, isOn);
        return this;
    }

    public StructConfigurationBuilder Private()
    {
        Configuration.Visibility = VisibilityModifier.Private;
        return this;
    }

    public StructConfigurationBuilder Protected()
    {
        Configuration.Visibility = VisibilityModifier.Protected;
        return this;
    }

    public StructConfigurationBuilder ProtectedInternal()
    {
        Configuration.Visibility = VisibilityModifier.ProtectedInternal;
        return this;
    }

    public StructConfigurationBuilder Sealed(bool isOn = true)
    {
        Configuration.ToggleModifier(TypeModifiers.Sealed, isOn);
        return this;
    }

    public StructConfigurationBuilder Static(bool isOn = true)
    {
        Configuration.ToggleModifier(TypeModifiers.Static, isOn);
        return this;
    }

    public StructConfigurationBuilder Unsafe(bool isOn = true)
    {
        Configuration.ToggleModifier(TypeModifiers.Unsafe, isOn);
        return this;
    }

    public StructConfigurationBuilder WithGenericParameter(string parameterName, params string[] constraints)
    {
        Configuration.GenericParameters[parameterName] = constraints;
        return this;
    }
}