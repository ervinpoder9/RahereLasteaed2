namespace Mvc.Data;

public sealed class GroupData : EntityData<GroupData> {
    public string? Name { get; set; }
    public int AmountOfChildren { get; set; }
}