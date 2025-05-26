using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Data;

public sealed class FoodAllergiesData : EntityData<FoodAllergiesData> {
    public string? AllergyName { get; set; }
    public string? Description { get; set; }
    public int? Severity { get; set; }
    public string? Reaction { get; set; }
}
