using Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Facade;

[DisplayName("Staff")] public sealed class AllStaffView : AllPersonsView
{
    [Display(Name = "CategoryName")] public int CategoryId { get; set; }
    [Display(Name = "CategoryName")] public string? CategoryName { get; set; }

    // Ametikoht
    private const string emPosition = "Position is required.";
    // Haridustase
    private const string haridustase = "Level of Education";
    private const string emEducation = "Level of Education is required.";
    

    // Ametikoht
    [Required(ErrorMessage = emPosition)] public string? Position { get; set; }

    // Haridustase
    [Required(ErrorMessage = emEducation)]
    [Display(Name = haridustase)]
    public EnumEducation? Education { get; set; }
}
