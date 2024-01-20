namespace Syntaxsmith.CSharp;

public enum PreprocessorDirective
{
    NullableDisable,
    NullableEnable,
    NullableRestore,
    NullableDisableAnnotations,
    NullableEnableAnnotations,
    NullableRestoreAnnotations,
    NullableDisableWarnings,
    NullableEnableWarnings,
    NullableRestoreWarnings,
    If,
    Else,
    Elif,
    EndIf,
    Region,
    EndRegion,
    Error,
    Warning,
    Line,
    Define,
}