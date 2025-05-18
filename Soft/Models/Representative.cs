using Helpers;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Soft.Models;

public class Representative: AllPersons
{
    // Esindusõigus
    [Required(ErrorMessage = "Right Of Representation is required.")]
    [Display(Name = "Esindusõigus")]
    public EnumRightOfRepresentation RightOfRepresentation { get; set; }

}
