using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;

namespace Syntaxsmith.CSharp.Configuration;

public class ClassConfigurationBuilder : TypeConfigurationBuilder<ClassConfigurationBuilder>
{
    public ClassConfigurationBuilder(string className)
        : base(className, "class")
    {
        GlobalConfiguration.Class?.Invoke(this);
    }

    public ClassConfigurationBuilder Abstract(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Abstract, isOn);
        return this;
    }

    public ClassConfigurationBuilder Body(Action<CSharpCodeBuilder> body)
    {
        Configuration.Body = body;
        return this;
    }

    public ClassConfigurationBuilder Implements(params string[] interfaces)
    {
        Configuration.Interfaces = interfaces;
        return this;
    }

    public ClassConfigurationBuilder Implements<T>()
    {
        return Implements(typeof(T).FriendlyName());
    }

    public ClassConfigurationBuilder Implements(params Type[] interfaces)
    {
        return Implements(interfaces.Select(x => x.FriendlyName()).ToArray());
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

        return Inherits(baseType.FriendlyName());
    }

    public ClassConfigurationBuilder Partial(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Partial, isOn);
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
        Configuration.ToggleModifier(KeywordModifiers.Sealed, isOn);
        return this;
    }

    public ClassConfigurationBuilder Static(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Static, isOn);
        return this;
    }

    public ClassConfigurationBuilder Unsafe(bool isOn = true)
    {
        Configuration.ToggleModifier(KeywordModifiers.Unsafe, isOn);
        return this;
    }

    public ClassConfigurationBuilder WithGenericParameter(string parameterName, params string[] constraints)
    {
        Configuration.GenericParameters[parameterName] = constraints;
        return this;
    }
}