using Syntaxsmith.CSharp.Enums;

namespace Syntaxsmith.CSharp.Interfaces;

internal interface IKeywordModifiable
{
    KeywordModifiers Modifiers { get; set; }
}