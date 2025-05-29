namespace Mvc.Data;

public sealed class FoodAllergiesData : EntityData<FoodAllergiesData> {
    public string? AllergyName { get; set; }
    public string? Reaction { get; set; }
    public string? Antidote { get; set; }
    
}
