using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Facade;

[DisplayName("Food Allergies")] public sealed class FoodAllergiesView : EntityView {
    [DisplayName("Allergy Name"), StringLength(60, MinimumLength = 3), Required] public string? AllergyName { get; set; }
    [StringLength(255, MinimumLength = 0)] public string? Reaction { get; set; }
    [StringLength(64, MinimumLength = 0)] public string? Antidote { get; set; }
}
