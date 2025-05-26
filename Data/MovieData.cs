namespace Mvc.Data;

public sealed class MovieData : EntityData<MovieData> {
    public string? Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public double? Price { get; set; }
    public string? Genre { get; set; }
    public string? Rating { get; set; }
}

