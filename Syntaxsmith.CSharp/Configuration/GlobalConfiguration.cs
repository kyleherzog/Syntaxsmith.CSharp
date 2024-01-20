namespace Syntaxsmith.CSharp.Configuration;

public static class GlobalConfiguration
{
    public static Action<ClassConfigurationBuilder>? Class { get; set; }

    public static Action<InterfaceConfigurationBuilder>? Interface { get; set; }

    public static Action<StructConfigurationBuilder>? Struct { get; set; }

    public static Action<EnumConfigurationBuilder>? Enum { get; set; }

    public static Action<CSharpFileConfigurationBuilder>? CSharpFile { get; set; }

    public static void Reset()
    {
        Class = null;
        Interface = null;
        Struct = null;
        Enum = null;
        CSharpFile = null;
    }
}
