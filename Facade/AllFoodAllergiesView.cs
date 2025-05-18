using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Facade;

[DisplayName("All Food Allergies")] public sealed class AllFoodAllergiesView : EntityView
{
    public string? AllergyName { get; set; }
}
