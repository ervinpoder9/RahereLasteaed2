using Mvc.Data;

namespace Mvc.Domain;

public class AllCategories(AllCategoriesData d) : Entity<AllCategoriesData>(d)
{
    public string? CategoryName => data?.CategoryName;
}
