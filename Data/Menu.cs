using System.ComponentModel.DataAnnotations;

namespace Mvc.Data;

public sealed class MenuData : EntityData<MenuData>
{
    [Required]
    public DateTime Date { get; set; }

    public string? Breakfast { get; set; }

    public string? Lunch { get; set; }

    public string? Snack { get; set; }

    public string? Notes { get; set; }
}