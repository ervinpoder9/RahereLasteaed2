using Mvc.Core;
using Mvc.Data;

namespace Mvc.Domain;

public class Absence(AbsenceData? d) : Entity<AbsenceData>(d) {
    public int ChildId => data?.ChildId ?? 0;
    public int GroupId => data?.GroupId ?? 0;
    public Children? Children => child;
    public Group? Group => group;
    internal Children? child;
    internal Group? group;
    public override async Task LoadLazy() {
        await base.LoadLazy();
        child = await Services.Get<IChildrenRepo>()?.GetAsync(ChildId)!;
        group = await Services.Get<IGroupsRepo>()?.GetAsync(GroupId)!;
    }
    public DateTime? AbsenceDate => data?.AbsenceDate;
}
