using Helpers;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Domain;

public class AllStaff : AllPersons
{    
    // Ametikoht
    [Required(ErrorMessage = "position is required.")]
    [Display(Name = "Ametikoht")]
    public string? position { get; set; }

    // Haridustase
    [Required(ErrorMessage = "Education is required.")]
    [Display(Name = "Haridustase")]
    public EnumEducation? education { get; set; }
}
