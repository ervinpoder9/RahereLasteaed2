using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Facade;

[DisplayName("Menüü")]
public sealed class MenuView : EntityView
{
    [Display(Name = "Kuupäev")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Kuupäev on kohustuslik")]
    public DateTime Date { get; set; }

    [Display(Name = "Hommikusöök")]
    [StringLength(500)]
    public string? Breakfast { get; set; }

    [Display(Name = "Lõunasöök")]
    [StringLength(500)]
    public string? Lunch { get; set; }

    [Display(Name = "Vahepala")]
    [StringLength(500)]
    public string? Snack { get; set; }

    [Display(Name = "Lisainfo")]
    [StringLength(500)]
    public string? Notes { get; set; }
}