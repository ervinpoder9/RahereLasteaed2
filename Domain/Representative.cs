using Helpers;
using Mvc.Core;
using Mvc.Data;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Domain;

public class Representative(RepresentativeData d): AllPersons<RepresentativeData>(d)
{
    internal List<ChildrenAndRep> relationship = [];
    public List<Children?> Child => relationship?
        .Where(r => r.Children is not null)
        .Select(r => r.Children)
        .ToList() ?? [];
    public override async Task LoadLazy()
    {
        await base.LoadLazy();
        relationship.Clear();
        var roles = await (Services.Get<IChildrenAndRepRepo>()?
            .GetAsync(nameof(ChildrenAndRep.RepresentativeId), Id ?? 0))!;
        foreach (var r in roles)
        {
            await r.LoadLazy();
            relationship.Add(r);
        }
    }
}
