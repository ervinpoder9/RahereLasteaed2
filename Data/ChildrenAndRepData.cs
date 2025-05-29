using Helpers;

namespace Mvc.Data;

public sealed class ChildrenAndRepData : EntityData<ChildrenAndRepData>
{
    public int ChildId { get; set; }
    public int RepresentativeId { get; set; }

    // Esindusõigus
    public EnumRightOfRepresentation RightOfRepresentation { get; set; }

    // Muu info
    public string? AdditionalInfo { get; set; }

}
