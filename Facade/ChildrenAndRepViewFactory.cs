using Mvc.Data;
using Mvc.Domain;

namespace Mvc.Facade;

public sealed class ChildrenAndRepViewFactory : AbstractViewFactory<ChildrenAndRepData, ChildrenAndRepView>
{
    public override async Task<ChildrenAndRepView> CreateView(ChildrenAndRepData? data, bool loadLazy = false)
    {
        var view = await base.CreateView(data, loadLazy);
        if (!loadLazy) return view;

        var o = new ChildrenAndRep(data);
        await o.LoadLazy();

        view.ChildFullName = $"{o.Children?.Name} {o.Children?.Surname}";
        view.RepresentativeFullName = $"{o.Representative?.Name} {o.Representative?.Surname}";

        return view;
    }
}
