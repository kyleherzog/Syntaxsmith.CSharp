using System.Text;
using Syntaxsmith.CSharp.Enums;

namespace Syntaxsmith.CSharp.Extensions;

internal static class TypeModifiersExtensions
{
    public static string ToKeywords(this TypeModifiers modifiers)
    {
        var keywords = new StringBuilder();

        if (modifiers.HasFlag(TypeModifiers.Static))
        {
            keywords.Append("static ");
        }

        if (modifiers.HasFlag(TypeModifiers.Abstract))
        {
            keywords.Append("abstract ");
        }

        if (modifiers.HasFlag(TypeModifiers.Sealed))
        {
            keywords.Append("sealed ");
        }

        if (modifiers.HasFlag(TypeModifiers.Record))
        {
            keywords.Append("record ");
        }

        if (modifiers.HasFlag(TypeModifiers.Unsafe))
        {
            keywords.Append("unsafe ");
        }

        if (modifiers.HasFlag(TypeModifiers.Partial))
        {
            keywords.Append("partial ");
        }

        return keywords.ToString();
    }

}