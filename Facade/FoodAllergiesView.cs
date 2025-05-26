using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Facade;

[DisplayName("Food Allergies")] public sealed class FoodAllergiesView : EntityView {
    [DisplayName("Name"), StringLength(60, MinimumLength = 3), Required] public string? AllergyName { get; set; }
    [StringLength(255, MinimumLength = 0)] public string? Description { get; set; }
    [Range(1, 10), Required] public int Severity { get; set; }
    [StringLength(255, MinimumLength = 0)] public string? Reaction { get; set; }
}
