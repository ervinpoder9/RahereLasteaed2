using Mvc.Data;

namespace Mvc.Domain;

public class AllFoodAllergies(AllFoodAllergiesData d) : Entity<AllFoodAllergiesData>(d)
{   
    public string? AllergyName => data?.AllergyName;
}
