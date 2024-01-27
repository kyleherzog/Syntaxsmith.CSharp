using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;

namespace Syntaxsmith.CSharp.Configuration;

public class EnumConfigurationBuilder : TypeConfigurationBuilder<EnumConfigurationBuilder>
{
    public EnumConfigurationBuilder(string enumName)
        : base(enumName, "enum")
    {
        GlobalConfiguration.Enum?.Invoke(this);
    }

    public EnumConfigurationBuilder UnderlyingType<T>()
    {
        return UnderlyingType(typeof(T));
    }

    public EnumConfigurationBuilder UnderlyingType(Type underlyingType)
    {
        return UnderlyingType(underlyingType.FriendlyName());
    }

    public EnumConfigurationBuilder UnderlyingType(string underlyingType)
    {
        Configuration.Inherits = underlyingType;
        return this;
    }

    public EnumConfigurationBuilder Private()
    {
        Configuration.Visibility = VisibilityModifier.Private;
        return this;
    }

    public EnumConfigurationBuilder Protected()
    {
        Configuration.Visibility = VisibilityModifier.Protected;
        return this;
    }

    public EnumConfigurationBuilder ProtectedInternal()
    {
        Configuration.Visibility = VisibilityModifier.ProtectedInternal;
        return this;
    }
}