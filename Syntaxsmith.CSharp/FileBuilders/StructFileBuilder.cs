using Syntaxsmith.CSharp.Configuration;

namespace Syntaxsmith.CSharp;

public class StructFileBuilder : CSharpFileBuilder<StructFileBuilder>
{
    public StructFileBuilder(string structName, Action<CSharpFileConfigurationBuilder>? configAction = null, SyntaxContext? context = null)
        : base(structName, configAction, context)
    {
    }

    public StructFileBuilder Open(Action<StructConfigurationBuilder>? configAction = null)
    {
        return OpenStruct(TypeName, configAction);
    }
}