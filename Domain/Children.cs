using Helpers;
using Mvc.Core;
using Mvc.Data;

namespace Mvc.Domain;

public class Children(ChildrenData d) : AllPersons<ChildrenData>(d)
{
    public int Age => data?.IDNumber != null ? ChildrenAge.GetAge(data.IDNumber) : 0;
    public int GroupId => data?.GroupId ?? 0;

    // Select nupp
    internal List<ChildrenAndRep> relationship = [];

    // Esindajad
    public List<Representative?> Representative => relationship?
        .Where(r => r.Representative is not null)
        .Select(r => r.Representative)
        .ToList() ?? [];

    // Esindusoigus
    public List<ChildrenAndRep> Relationship => relationship;

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
