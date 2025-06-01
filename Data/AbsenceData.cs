namespace Mvc.Data;

public sealed class AbsenceData : EntityData<AbsenceData> {
    public int GroupId { get; set; }
    public int ChildId { get; set; }
    public DateTime AbsenceDate { get; set; }
    public DateTime SubmissionDate { get; set; }
}