using Mvc.Data;

namespace Mvc.Domain;

public class FoodAllergies(FoodAllergiesData? d) : Entity<FoodAllergiesData>(d) {   
    public string? AllergyName => data?.AllergyName;
    public string? Reaction => data?.Reaction;
    public string? Antidote => data?.Antidote;
}
