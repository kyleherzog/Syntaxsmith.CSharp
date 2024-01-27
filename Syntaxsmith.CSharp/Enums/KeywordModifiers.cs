namespace Syntaxsmith.CSharp.Enums;

[Flags]
internal enum KeywordModifiers
{
    File = 1 << 0,
    Static = 1 << 1,
    Extern = 1 << 2,
    New = 1 << 3,
    Virtual = 1 << 4,
    Abstract = 1 << 5,
    Sealed = 1 << 6,
    Record = 1 << 7,
    Override = 1 << 8,
    Readonly = 1 << 9,
    Unsafe = 1 << 10,
    Required = 1 << 11,
    Volatile = 1 << 12,
    Async = 1 << 13,
    Partial = 1 << 14,
}
