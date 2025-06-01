using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc.Data;

public sealed class AbsenceData : EntityData<AbsenceData> {
    public int GroupId { get; set; }
    public int ChildId { get; set; }
    public DateTime AbsenceDate { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)] public DateTime CreatedAt { get; set; }
}