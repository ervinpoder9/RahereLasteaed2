namespace Mvc.Data;

public sealed class ChildrenFoodAllergiesData: EntityData<ChildrenFoodAllergiesData> {
    public int ChildrenId { get; set; }
    public int FoodAllergyId { get; set; }
}
