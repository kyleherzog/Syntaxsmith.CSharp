namespace Syntaxsmith.CSharp.Interfaces;

internal interface IConfigurationFormatter
{
    bool ShouldIndentChildLines { get; }

    IList<string> ToLines();
}