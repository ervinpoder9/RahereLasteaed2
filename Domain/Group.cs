using Mvc.Core;
using Mvc.Data;

namespace Mvc.Domain;

public class Group(GroupData? d): Entity<GroupData>(d) {
    public string? Name => data?.Name;
    public int? Capacity => data?.Capacity;
    public string? PrimaryTeacher => data?.PrimaryTeacher;
    public string? AssistantTeacher => data?.AssistantTeacher;
    public int? RoomNumber => data?.RoomNumber;
    internal List<Children> children = [];
    public override async Task LoadLazy() {
        await base.LoadLazy();
        children.Clear();
        var child = await (Services.Get<IChildrenRepo>()?
            .GetAsync(nameof(MovieRole.MovieId), Id ?? 0))!;
        foreach (var c in child) {
            await c.LoadLazy();
            children.Add(c);
        }
    }
}

