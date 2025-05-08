using System.ComponentModel.DataAnnotations;

namespace Mvc.Facade;

public sealed class TestingView : EntityView {
    public bool Boolean { get; set; }
    public char Char { get; set; }
    public DateTime DateTime { get; set; }
    public decimal Decimal { get; set; }
    public double Double { get; set; }
    public float Float { get; set; }
    public sbyte Int8 { get; set; }
    public short Int16 { get; set; }
    public int Int32 { get; set; }
    public long Int64 { get; set; }
    public string String { get; set; } = string.Empty;
    public byte UInt8 { get; set; }
    public ushort UInt16 { get; set; }
    public uint UInt32 { get; set; }
    public ulong UInt64 { get; set; }
    [Display(Name = "Bool?")] public bool? NullBoolean { get; set; }
    [Display(Name = "Char?")] public char? NullChar { get; set; }
    [Display(Name = "DateTime?")] public DateTime? NullDateTime { get; set; }
    [Display(Name = "Decimal?")] public decimal? NullDecimal { get; set; }
    [Display(Name = "Double?")] public double? NullDouble { get; set; }
    [Display(Name = "Float?")] public float? NullFloat { get; set; }
    [Display(Name = "Int8?")] public sbyte? NullInt8 { get; set; }
    [Display(Name = "Int16?")] public short? NullInt16 { get; set; }
    [Display(Name = "Int32?")] public int? NullInt32 { get; set; }
    [Display(Name = "Int64?")] public long? NullInt64 { get; set; }
    [Display(Name = "String?")] public string? NullString { get; set; }
    [Display(Name = "UInt8?")] public byte? NullUInt8 { get; set; }
    [Display(Name = "Uint16?")] public ushort? NullUInt16 { get; set; }
    [Display(Name = "UInt32?")] public uint? NullUInt32 { get; set; }
    [Display(Name = "UInt64?")] public ulong? NullUInt64 { get; set; }
}