namespace Syntaxsmith.CSharp.Extensions;

internal static class TypeExtensions
{
    public static string FriendlyName(this Type? type)
    {
        if (type is null)
        {
            return string.Empty;
        }

        if (type.IsGenericType)
        {
            var name = type.Name.Substring(0, type.Name.IndexOf("`", StringComparison.Ordinal));
            var types = string.Join(", ", type.GetGenericArguments().Select(FriendlyName));
            return $"{name}<{types}>";
        }
        else
        {
            return type.IsByRef
                ? type.Name.TrimEnd('&')
                : type.Name;
        }
    }
}