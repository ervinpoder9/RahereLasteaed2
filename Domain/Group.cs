using Mvc.Data;

namespace Mvc.Domain;

public class Group(GroupData? d): Entity<GroupData>(d) {
    public string? Name => data?.Name;
    public int? AmountOfChildren => data?.AmountOfChildren;
}

