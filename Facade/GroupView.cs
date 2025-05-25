using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Facade;

[DisplayName("Group")] public sealed class GroupView : EntityView {
    internal const string nameEx = @"^[A-Z][a-zA-Z0-9\s]*$";
    [Display(Name = "Name"), RegularExpression(nameEx), 
     StringLength(60, MinimumLength = 3), Required] public string? Name { get; set; }
    [Display(Name = "Group Size"), Range(0, 35), Required] public int Capacity { get; set; }
    [Display(Name = "Primary Teacher"), StringLength(60, MinimumLength = 3)] public string? PrimaryTeacher { get; set; }
    [Display(Name = "Assistant Teacher"), StringLength(60, MinimumLength = 3)] public string? AssistantTeacher { get; set; }
    [Display(Name = "Room Number"), Range(1, 500)] public int RoomNumber { get; set; }
}
