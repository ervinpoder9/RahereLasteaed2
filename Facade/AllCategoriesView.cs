using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Facade;

[DisplayName("Staff by Categories")] public sealed class AllCategoriesView : EntityView
{
    [Display(Name = "Category")] public string? CategoryName { get; set; }
}
