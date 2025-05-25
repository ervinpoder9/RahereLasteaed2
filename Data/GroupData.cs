namespace Mvc.Data;

public sealed class GroupData : EntityData<GroupData> {
    public string Name { get; set; }
    public int Capacity { get; set; }
    public string PrimaryTeacher { get; set; }
    public string AssistantTeacher { get; set; }
    public int RoomNumber { get; set; }
}