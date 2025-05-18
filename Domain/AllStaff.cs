using Helpers;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Domain;

public class AllStaff : AllPersons
{    
    // Ametikoht
    [Required(ErrorMessage = "Position is required.")]
    [Display(Name = "Ametikoht")]
    public string? Position { get; set; }

    // Haridustase
    [Required(ErrorMessage = "Education is required.")]
    [Display(Name = "Haridustase")]
    public EnumEducation? Education { get; set; }
}
