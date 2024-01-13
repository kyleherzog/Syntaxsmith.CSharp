using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

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
}
