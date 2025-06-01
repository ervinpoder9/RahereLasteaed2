using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Mvc.Core.Helpers;
using Mvc.Data;

namespace Mvc.Facade;

[DisplayName("Absence")]
public sealed class AbsenceView : EntityView {
    [Display(Name = "Absence Date"), DataType(DataType.Date), FutureDate(ErrorMessage = "Absence can only be marked for future dates.")] public DateTime AbsenceDate { get; set; }
    [Display(Name = "Submitted At"), DataType(DataType.DateTime)] public DateTime CreatedAt { get; private set; }
    [Display(Name = "Group")] public int GroupId { get; set; }
    [Display(Name = "Child")] public int ChildId { get; set; }
    [Display(Name = "Group")] public string? Group { get; set; }
    [Display(Name = "Child")] public string? Child { get; set; }
}

