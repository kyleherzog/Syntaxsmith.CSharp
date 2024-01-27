using System.Text;

namespace Syntaxsmith.CSharp.Enums;

internal static class KeywordModifersExtensions
{
    public static string ToCodeText(this KeywordModifiers modifiers)
    {
        var keywords = new StringBuilder();
        foreach (Enum value in Enum.GetValues(typeof(KeywordModifiers)))
        {
            if (modifiers.HasFlag(value))
            {
                keywords.Append(value.ToString().ToLowerInvariant());
                keywords.Append(' ');
            }
        }

        return keywords.ToString();
    }
}