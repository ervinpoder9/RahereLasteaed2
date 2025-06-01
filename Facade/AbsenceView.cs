using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Mvc.Data;

namespace Mvc.Facade;

[DisplayName("Absence")]
public sealed class AbsenceView : EntityView {
    internal const string absenceDate = "Absence Date";
    internal const string submissionDate = "Submission Date";
    [Display(Name = absenceDate), DataType(DataType.Date)] public DateTime AbsenceDate { get; set; }
    [Display(Name = submissionDate), DataType(DataType.DateTime)] public DateTime SubmissionDate { get; set; }
    [Display(Name = "Group")] public int GroupId { get; set; }
    [Display(Name = "Child")] public int ChildId { get; set; }
    [Display(Name = "Group")] public string? Group { get; set; }
    [Display(Name = "Child")] public string? Child { get; set; }
}

