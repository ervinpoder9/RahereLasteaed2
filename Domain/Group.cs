using Mvc.Data;

namespace Mvc.Domain;

public class Group(GroupData? d): Entity<GroupData>(d) {
    public string? Name => data?.Name;
    public int? Capacity => data?.Capacity;
    public string? PrimaryTeacher => data?.PrimaryTeacher;
    public string? AssistantTeacher => data?.AssistantTeacher;
    public int? RoomNumber => data?.RoomNumber;
}

