using Mvc.Data;
using Mvc.Domain;

namespace Mvc.Facade;

public sealed class AbsenceViewFactory : AbstractViewFactory<AbsenceData, AbsenceView> {
    public static AbsenceView Create(Absence absence) {
        var view = new AbsenceView {
            Id = absence.Id ?? 0,
            AbsenceDate = absence.AbsenceDate ?? DateTime.MinValue,
            CreatedAt = absence.data?.CreatedAt ?? DateTime.MinValue,
            Group = absence.GroupId.ToString(),
            Child = absence.ChildId.ToString(),
        };
        typeof(AbsenceView).GetProperty(nameof(AbsenceView.CreatedAt))!
            .SetValue(view, absence.data?.CreatedAt ?? DateTime.MinValue);
        return view;
    }
    public override async Task<AbsenceView> CreateView(AbsenceData? d, bool loadLazy = false) {
        var v = await base.CreateView(d, loadLazy);
        if (!loadLazy) return v;
        var o = new Absence(d);
        await o.LoadLazy();
        v.Group = o.GroupId.ToString();
        v.Child = o.ChildId.ToString();
        return v;
    }
}
