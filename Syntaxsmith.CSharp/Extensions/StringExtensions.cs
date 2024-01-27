using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Syntaxsmith.CSharp.Extensions;

public static class StringExtensions
{
    private const string validationPattern = @"^(?:[A-Z][a-zA-Z0-9]*)(?:<[A-Z][a-zA-Z0-9]*>)?$";

    public static void ValidateAsObjectIdentifier(this string identifier)
    {
        if (identifier is null)
        {
            throw new ArgumentNullException(nameof(identifier));
        }

        var isValidName = Regex.IsMatch(identifier, validationPattern);

        if (!isValidName)
        {
            throw new ArgumentException($"'{identifier}' is not a valid object identifier.");
        }
    }
}
