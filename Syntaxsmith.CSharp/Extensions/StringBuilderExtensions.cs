using System.Text;

namespace Syntaxsmith.CSharp.Extensions;

internal static class StringBuilderExtensions
{
    public static StringBuilder AppendIf(this StringBuilder builder, bool condition, params string?[] text)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        if (condition)
        {
            foreach (var item in text)
            {
                builder.Append(item);
            }
        }

        return builder;
    }
}