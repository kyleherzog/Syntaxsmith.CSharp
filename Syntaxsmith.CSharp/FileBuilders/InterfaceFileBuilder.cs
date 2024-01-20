using Syntaxsmith.CSharp.Configuration;

namespace Syntaxsmith.CSharp;

public class InterfaceFileBuilder : CSharpFileBuilder<InterfaceFileBuilder>
{
    public InterfaceFileBuilder(string interfaceName, Action<CSharpFileConfigurationBuilder>? configAction = null, SyntaxContext? context = null)
        : base(interfaceName, configAction, context)
    {
    }

    public InterfaceFileBuilder Open(Action<InterfaceConfigurationBuilder>? configAction = null)
    {
        return InterfaceOpen(TypeName, configAction);
    }
}