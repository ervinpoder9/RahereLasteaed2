using Mvc.Core;
using Mvc.Data;

namespace Mvc.Domain;

public class AllCategories(AllCategoriesData d) : Entity<AllCategoriesData>(d)
{
    public string? CategoryName => data?.CategoryName;

    internal List<AllStaff> staffByCategory = [];
    public List<AllStaff?> Staff => staffByCategory?.Where(r => r is not null).ToList() ?? [];
    public override async Task LoadLazy()
    {
        await base.LoadLazy();
        staffByCategory.Clear();
        var repo = Services.Get<IAllStaffRepo>();
        var allStaff = await repo?.GetAsync(nameof(AllStaff.CategoryId), Id ?? 0)!;

        foreach (var s in allStaff)
        {
            await s.LoadLazy();
            staffByCategory.Add(s);
        }
    }
}
