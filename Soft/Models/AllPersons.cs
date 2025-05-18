using System.ComponentModel.DataAnnotations;

namespace Mvc.Soft.Models;

public class AllPersons
{
    public int Id { get; set; }
    // Eesnimi
    [Required(ErrorMessage = "name is required.")]
    [MinLength(2, ErrorMessage = "name must be at least 2 characters long.")]
    [RegularExpression(@"^[a-zA-ZäöüõšžÄÖÜÕŠŽ]+([ -][a-zA-ZäöüõšžÄÖÜÕŠŽ]+)*$", ErrorMessage = "name can only contain letters, spaces, and hyphens.")]
    [Display(Name = "Eesnimi")]
    public string? Name { get; set; }

    // Perekonnanimi
    [Required(ErrorMessage = "surname name is required.")]
    [MinLength(2, ErrorMessage = "surname must be at least 2 characters long.")]
    [RegularExpression(@"^[a-zA-ZäöüõšžÄÖÜÕŠŽ]+([ -][a-zA-ZäöüõšžÄÖÜÕŠŽ]+)*$", ErrorMessage = "surname can only contain letters, spaces, and hyphens.")]
    [Display(Name = "Perekonnanimi")]
    public string? Surname { get; set; }

    // Isikukood
    [Required(ErrorMessage = "ID Number is required.")]
    [StringLength(11, ErrorMessage = "ID Number must be 11 characters long.")]
    [RegularExpression(@"^[3456]\d{10}$", ErrorMessage = "ID Number must start with 3, 4, 5 or 6.")]
    [Display(Name = "Isikukood")]
    public string? IDNumber { get; set; }

    // Aadress
    [Required(ErrorMessage = "address is required.")]
    [Display(Name = "Aadress")]
    public string? Address { get; set; }

    // Telefoninumber
    [Display(Name = "Telefoninumber")]
    public string? Mobile { get; set; }

    // E-mail
    [DataType(DataType.EmailAddress)]
    [Display(Name = "E-mail")]
    public string? Email { get; set; }

    // Muu oluline info
    [Display(Name = "Muu info")]
    public string? AdditionalInfo { get; set; }

}
