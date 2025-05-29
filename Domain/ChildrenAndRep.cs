using Helpers;
using Mvc.Core;
using Mvc.Data;

namespace Mvc.Domain;

public class ChildrenAndRep(ChildrenAndRepData d) : Entity<ChildrenAndRepData>(d)
{
    public int ChildId => data?.ChildId ?? 0;
    public int RepresentativeId => data?.RepresentativeId ?? 0;

    public EnumRightOfRepresentation? RightOfRepresentation => data?.RightOfRepresentation;
    public string? AdditionalInfo => data?.AdditionalInfo;

    // ChildrenAndRep <=> Children
    public Children? Children => child;
    internal Children? child;

    // ChildrenAndRep <=> Representative
    public Representative? Representative => representative;
    internal Representative? representative;

    public override async Task LoadLazy()
    {
        await base.LoadLazy();
        child = await Services.Get<IChildrenRepo>()?.GetAsync(ChildId)!;
        representative = await Services.Get<IRepresentativesRepo>()?.GetAsync(RepresentativeId)!;
    }
}
