namespace Syntaxsmith.CSharp.Configuration;

public static class GlobalConfiguration
{
    public static Action<ClassConfigurationBuilder>? Class { get; set; }

    public static Action<ConstConfigurationBuilder>? Const { get; set; }

    public static Action<CSharpFileConfigurationBuilder>? CSharpFile { get; set; }

    public static Action<EnumConfigurationBuilder>? Enum { get; set; }

    public static Action<FieldConfigurationBuilder>? Field { get; set; } = x => x.Private();

    public static Action<MethodConfigurationBuilder>? Method { get; set; }

    public static Action<InterfaceConfigurationBuilder>? Interface { get; set; }

    public static Action<PropertyConfigurationBuilder>? Property { get; set; }

    public static Action<StructConfigurationBuilder>? Struct { get; set; }

    public static void Reset()
    {
        Class = null;
        Const = null;
        Interface = null;
        Struct = null;
        Enum = null;
        Field = x => x.Private();
        Method = null;
        CSharpFile = null;
    }
}