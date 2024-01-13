namespace Syntaxsmith.CSharp.Enums;

[Flags]
internal enum TypeModifiers
{
    Abstract = 1 << 0,
    Sealed = 1 << 1,
    Static = 1 << 2,
    Partial = 1 << 3,
    Unsafe = 1 << 4,
    Record = 1 << 5,
}
