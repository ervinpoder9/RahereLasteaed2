using Mvc.Core;
using System;
using Mvc.Data;

namespace Mvc.Domain;

public sealed class MovieRole(MovieRoleData? d) : Entity<MovieRoleData>(d) {
    public int MovieId => data?.MovieId ?? 0;
    public int GroupNameId => data?.PersonNameId ?? 0;
    public string? Text => data?.Text;
    public Roles? Role => data?.Role;
    public bool? IsCredited => data?.IsCredited;
    public Movie? Movie => movie;
    public Group? Group => group;
    internal Movie? movie;
    internal Group? group;
    public override async Task LoadLazy() {
        await base.LoadLazy();
        movie = await Services.Get<IMoviesRepo>()?.GetAsync(MovieId)!;
        group = await Services.Get<IGroupsRepo>()?.GetAsync(GroupNameId)!;
    }
}
