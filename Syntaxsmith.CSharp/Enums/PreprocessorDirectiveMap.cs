namespace Syntaxsmith.CSharp.Enums;

internal static class PreprocessorDirectiveMap
{
    // map of PreprocessorDirective to string representation
    private static readonly Dictionary<PreprocessorDirective, string> map = new()
    {
        [PreprocessorDirective.NullableDisable] = "nullable disable",
        [PreprocessorDirective.NullableEnable] = "nullable enable",
        [PreprocessorDirective.NullableRestore] = "nullable restore",
        [PreprocessorDirective.NullableDisableAnnotations] = "nullable disable annotations",
        [PreprocessorDirective.NullableEnableAnnotations] = "nullable enable annotations",
        [PreprocessorDirective.NullableRestoreAnnotations] = "nullable restore annotations",
        [PreprocessorDirective.NullableDisableWarnings] = "nullable disable warnings",
        [PreprocessorDirective.NullableEnableWarnings] = "nullable enable warnings",
        [PreprocessorDirective.NullableRestoreWarnings] = "nullable restore warnings",
        [PreprocessorDirective.If] = "if",
        [PreprocessorDirective.Else] = "else",
        [PreprocessorDirective.Elif] = "elif",
        [PreprocessorDirective.EndIf] = "endif",
        [PreprocessorDirective.Region] = "region",
        [PreprocessorDirective.EndRegion] = "endregion",
        [PreprocessorDirective.Error] = "error",
        [PreprocessorDirective.Warning] = "warning",
        [PreprocessorDirective.Line] = "line",
        [PreprocessorDirective.Define] = "define",
    };

    internal static string DirectiveText(this PreprocessorDirective directive)
    {
        return map[directive];
    }
}