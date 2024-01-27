using Syntaxsmith.CSharp.Configuration;

namespace Syntaxsmith.CSharp;

public class ClassFileBuilder : CSharpFileBuilder<ClassFileBuilder>
{
    public ClassFileBuilder(string className, Action<CSharpFileConfigurationBuilder>? configAction = null, SyntaxContext? context = null)
        : base(className, configAction, context)
    {
    }

    public ClassFileBuilder Open(Action<ClassConfigurationBuilder>? configAction = null)
    {
        return OpenClass(TypeName, configAction);
    }
}