using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Facade;

[DisplayName("All Persons")] public abstract class AllPersonsView : EntityView
{
    // Nimi
    private const string emName = "Name and surname are required.";
    private const int minLengthName = 2;
    private const string emMinLength = "Name and surname must be at least 2 characters long.";
    private const string regularexpressionName = @"^[a-zA-ZäöüõšžÄÖÜÕŠŽ]+([ -][a-zA-ZäöüõšžÄÖÜÕŠŽ]+)*$";
    private const string emRegularexpressionName = "Name and surname can only contain letters, spaces, and hyphens.";
    // Isikukood
    private const string isikukood = "ID Number";
    private const string emID = "ID Number is required.";
    private const int lengthID = 11;
    private const string emLengthID = "ID Number must be 11 characters long and start with 3, 4, 5 or 6.";
    private const string regularexpressionID = @"^[3456]\d{10}$";
    // Aadress
    private const string emAddress = "Address is required.";
    // Muu info
    private const string lisainfo = "Additional Info";


    // Nimi
    [Required(ErrorMessage = emName)]
    [MinLength(minLengthName, ErrorMessage = emMinLength)]
    [RegularExpression(regularexpressionName, ErrorMessage = emRegularexpressionName)]
    public string? Name { get; set; }

    // Perekonnanimi    
    [Required(ErrorMessage = emName)]
    [MinLength(minLengthName, ErrorMessage = emMinLength)]
    [RegularExpression(regularexpressionName, ErrorMessage = emRegularexpressionName)]
    public string? Surname { get; set; }

    // Isikukood    
    [Required(ErrorMessage = emID)]
    [StringLength(lengthID, ErrorMessage = emLengthID)]
    [RegularExpression(regularexpressionID, ErrorMessage = emLengthID)]
    [Display(Name = isikukood)]
    public string? IDNumber { get; set; }

    // Aadress
    [Required(ErrorMessage = emAddress)] public string? Address { get; set; }

    // Telefoninumber
    public string? Mobile { get; set; }

    // E-mail
    [DataType(DataType.EmailAddress)] public string? Email { get; set; }
   
    // Muu oluline info
    [Display(Name = lisainfo)] public string? AdditionalInfo { get; set; }
}
