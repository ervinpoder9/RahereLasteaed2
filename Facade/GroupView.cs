using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Facade;

[DisplayName("Group")] public sealed class GroupView : EntityView {
    internal const string nameEx = @"^[A-Z][a-zA-Z0-9\s]*$";
    internal const string name = "Name";
    [Display(Name = name), RegularExpression(nameEx), 
     StringLength(60, MinimumLength = 3), Required] public string? Name { get; set; }
    [Display(Name = "Group Size"), Range(1, 35), Required] public int AmountOfChildren { get; set; }
}
