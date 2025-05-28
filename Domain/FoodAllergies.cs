using Mvc.Data;

namespace Mvc.Domain;

public class FoodAllergies(FoodAllergiesData? d) : Entity<FoodAllergiesData>(d) {   
    public string? AllergyName => data?.AllergyName;
    public string? Description => data?.Description;
    public int? Severity => data?.Severity;
    public string? Reaction => data?.Reaction;
}
