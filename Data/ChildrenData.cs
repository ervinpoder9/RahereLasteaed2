using Helpers;

namespace Mvc.Data;

public sealed class ChildrenData : AllPersonsData<ChildrenData>
{
    public int Age => IDNumber != null ? ChildrenAge.GetAge(IDNumber) : 0;
    public int GroupId { get; set; }
}
