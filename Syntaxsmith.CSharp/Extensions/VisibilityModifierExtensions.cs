using Syntaxsmith.CSharp.Enums;

namespace Syntaxsmith.CSharp;

internal static class VisibilityModifierExtensions
{
    public static string ToKeywords(this VisibilityModifier modifier)
    {
        if (modifier == VisibilityModifier.ProtectedInternal)
        {
            return "protected internal";
        }

        return modifier.ToString().ToLowerInvariant();
    }
}