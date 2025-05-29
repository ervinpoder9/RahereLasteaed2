using Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Facade;

[DisplayName("Children")] public sealed class ChildrenView : AllPersonsView {
    //public int Age => IDNumber != null ? ChildrenAge.GetAge(IDNumber) : 0;
    [Display(Name = "Group")] public int GroupId { get; set; }
}
