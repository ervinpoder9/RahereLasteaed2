using Helpers;

namespace Mvc.Data;

public sealed class AllStaffData : AllPersonsData<AllStaffData>
{
    public int CategoryId { get; set; }
    public string? Position { get; set; }
    public EnumEducation? Education { get; set; }
}

