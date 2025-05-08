using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Mvc.Data;

namespace Mvc.Facade;

[DisplayName("Movie Role")] public sealed class MovieRoleView : EntityView {
    [Display(Name = "Movie")] public int MovieId { get; set; }
    [Display(Name = "Group")] public int PersonNameId { get; set; }
    [Display(Name = "Movie")] public string? Movie { get; set; }
    [Display(Name = "Group")] public string? Person { get; set; }
    public string? Text { get; set; }
    public Roles? Role { get; set; }
    [Display(Name = "Is Credited")] public bool? IsCredited { get; set; }
}


