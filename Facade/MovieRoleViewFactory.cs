using Mvc.Data;
using Mvc.Domain;

namespace Mvc.Facade;

public sealed class MovieRoleViewFactory : AbstractViewFactory<MovieRoleData, MovieRoleView> {
    public override async Task<MovieRoleView> CreateView(MovieRoleData? d, bool loadLazy = false) {
        var v = await base.CreateView(d, loadLazy);
        if (!loadLazy) return v;
        var o = new MovieRole(d);
        await o.LoadLazy();
        v.Movie = o.Movie?.Title;
        v.Person = o.Group?.Name;
        return v;
    }
}
