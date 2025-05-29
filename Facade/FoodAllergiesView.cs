using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Facade;

[DisplayName("Food Allergies")] public sealed class FoodAllergiesView : EntityView {
    [DisplayName("Allergy Name"), StringLength(60, MinimumLength = 3), Required] public string? AllergyName { get; set; }
    [StringLength(255, MinimumLength = 0)] public string? Reaction { get; set; }
    [StringLength(64, MinimumLength = 0)] public string? Antidote { get; set; }
}
