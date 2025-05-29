using Mvc.Data;
using Mvc.Domain;

namespace Mvc.Facade;

public sealed class AllStaffViewFactory : AllPersonsViewFactory<AllStaffData, AllStaffView>
{
    public override async Task<AllStaffView> CreateView(AllStaffData? data, bool loadLazy = false)
    {
        var view = await base.CreateView(data, loadLazy);
        if (!loadLazy) return view;

        var entity = new AllStaff(data);
        await entity.LoadLazy();
        view.CategoryName = entity.Category?.CategoryName;

        return view;
    }
}
