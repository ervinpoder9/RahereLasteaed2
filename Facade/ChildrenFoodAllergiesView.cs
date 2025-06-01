using Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Facade;

[DisplayName("Children")] public sealed class ChildrenFoodAllergiesView : EntityView {
    [DisplayName("Child")] public int ChildrenId { get; set; }
    [DisplayName("Food Allergy")]public int FoodAllergyId { get; set; }
    [DisplayName("Child")] public string? Children { get; set; }
    [DisplayName("Food Allergy")] public string? FoodAllergy { get; set; }
}
