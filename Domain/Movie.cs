using Mvc.Core;
using Mvc.Data;

namespace Mvc.Domain;

public class Movie(MovieData? d) : Entity<MovieData>(d) {
    public string? Title => data?.Title;
    public DateTime? ReleaseDate => data?.ReleaseDate;
    public double? Price => data?.Price;
    public string? Genre => data?.Genre;
    public string? Rating => data?.Rating;
    internal List<MovieRole> movieRoles = [];
    public List<Group?> Roles => movieRoles?
        .Where(r => r.Group is not null)
        .Select(r => r.Group)
        .ToList() ?? [];
    public override async Task LoadLazy() {
        await base.LoadLazy();
        movieRoles.Clear();
        var roles = await (Services.Get<IMovieRolesRepo>()?
            .GetAsync(nameof(MovieRole.MovieId), Id ?? 0))!;
        foreach (var r in roles) {
            await r.LoadLazy();
            movieRoles.Add(r);
        }
    }
}
