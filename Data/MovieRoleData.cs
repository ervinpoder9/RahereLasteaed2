namespace Mvc.Data;

public sealed class MovieRoleData : EntityData<MovieRoleData> {
    public int MovieId { get; set; }
    public int PersonNameId { get; set; }
    public string? Text { get; set; }
    public Roles? Role { get; set; }
    public bool? IsCredited { get; set; }
}

