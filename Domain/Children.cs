using Helpers;
using Mvc.Core;
using Mvc.Data;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Domain;

public class Children(ChildrenData d) : AllPersons<ChildrenData>(d)
{
    public int Age => data?.IDNumber != null ? ChildrenAge.GetAge(data.IDNumber) : 0;

    // Select nupp
    internal List<ChildrenAndRep> relationship = [];
    public List<Representative?> Representative => relationship?
        .Where(r => r.Representative is not null)
        .Select(r => r.Representative)
        .ToList() ?? [];
    public override async Task LoadLazy()
    {
        await base.LoadLazy();
        relationship.Clear();
        var roles = await (Services.Get<IChildrenAndRepRepo>()?
            .GetAsync(nameof(ChildrenAndRep.ChildId), Id ?? 0))!;
        foreach (var r in roles)
        {
            await r.LoadLazy();
            relationship.Add(r);
        }
    }

}
