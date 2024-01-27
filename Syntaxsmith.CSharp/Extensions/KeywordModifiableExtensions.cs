using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Interfaces;

namespace Syntaxsmith.CSharp;

internal static class KeywordModifiableExtensions
{
    public static void ToggleModifier(this IKeywordModifiable modifiable, KeywordModifiers modifier, bool isOn)
    {
        if (isOn)
        {
            modifiable.Modifiers |= modifier;
        }
        else
        {
            modifiable.Modifiers &= ~modifier;
        }
    }
}