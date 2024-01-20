using Syntaxsmith.CSharp.Configuration;

namespace Syntaxsmith.CSharp;

public class EnumFileBuilder : CSharpFileBuilder<EnumFileBuilder>
{
    public EnumFileBuilder(string enumName, Action<CSharpFileConfigurationBuilder>? configAction = null, SyntaxContext? context = null)
        : base(enumName, configAction, context)
    {
    }

    public EnumFileBuilder Open(Action<EnumConfigurationBuilder>? configAction = null)
    {
        return EnumOpen(TypeName, configAction);
    }
}