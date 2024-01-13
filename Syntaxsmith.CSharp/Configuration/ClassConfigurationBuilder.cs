using Syntaxsmith.CSharp.Enums;

namespace Syntaxsmith.CSharp.Configuration;

public class ClassConfigurationBuilder : TypeConfigurationBuilder<ClassConfigurationBuilder>
{
    public ClassConfigurationBuilder(string className)
        : base(className, "class")
    {
    }

    public ClassConfigurationBuilder Abstract(bool isOn = true)
    {
        Configuration.ToggleModifier(TypeModifiers.Abstract, isOn);
        return this;
    }

    public ClassConfigurationBuilder Implements(params string[] interfaces)
    {
        Configuration.Interfaces = interfaces;
        return this;
    }

    public ClassConfigurationBuilder Implements<T>()
    {
        return Implements(typeof(T).Name);
    }

    public ClassConfigurationBuilder Implements(params Type[] interfaces)
    {
        return Implements(interfaces.Select(x => x.Name).ToArray());
    }

    public ClassConfigurationBuilder Inherits(string baseClass)
    {
        Configuration.Inherits = baseClass;
        return this;
    }

    public ClassConfigurationBuilder Inherits<T>()
    {
        return Inherits(typeof(T));
    }

    public ClassConfigurationBuilder Inherits(Type baseType)
    {
        if (baseType is null)
        {
            throw new ArgumentNullException(nameof(baseType));
        }

        return Inherits(baseType.Name);
    }

    public ClassConfigurationBuilder Partial(bool isOn = true)
    {
        Configuration.ToggleModifier(TypeModifiers.Partial, isOn);
        return this;
    }

    public ClassConfigurationBuilder Private()
    {
        Configuration.Visibility = VisibilityModifier.Private;
        return this;
    }

    public ClassConfigurationBuilder Protected()
    {
        Configuration.Visibility = VisibilityModifier.Protected;
        return this;
    }

    public ClassConfigurationBuilder ProtectedInternal()
    {
        Configuration.Visibility = VisibilityModifier.ProtectedInternal;
        return this;
    }

    public ClassConfigurationBuilder Sealed(bool isOn = true)
    {
        Configuration.ToggleModifier(TypeModifiers.Sealed, isOn);
        return this;
    }

    public ClassConfigurationBuilder Static(bool isOn = true)
    {
        Configuration.ToggleModifier(TypeModifiers.Static, isOn);
        return this;
    }

    public ClassConfigurationBuilder Unsafe(bool isOn = true)
    {
        Configuration.ToggleModifier(TypeModifiers.Unsafe, isOn);
        return this;
    }

    public ClassConfigurationBuilder WithGenericParameter(string parameterName, params string[] constraints)
    {
        Configuration.GenericParameters[parameterName] = constraints;
        return this;
    }
}