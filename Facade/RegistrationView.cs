using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Facade;

[DisplayName("Registration")] public class RegistrationView : EntityView {
    internal const string regNr = "Reg Number";
    internal const string regNrEx = @"^[A-Z][0-9]{5}$";
    internal const string RegDt = "Reg Date";
    internal const string groupNr = "Group Number";
    internal const string groupNrEx = @"^[A-Z]+[a-zA-Z0-9\s]*$";
    internal const string groupStart = "Group Start";
    internal const string groupEnd = "Group End";
    internal const string Child = "Child";
    internal const string ChildEx = @"^[A-Z]+[a-zA-Z\s]*$";
    internal const string Guardian = "Guardian";
    internal const string GuardianEx = @"^[A-Z]+[a-zA-Z\s]*$";
    [Display(Name = regNr)][RegularExpression(regNrEx)][Required] public string? RegistrationNumber { get; set; }
    [Display(Name = RegDt)][DataType(DataType.Date)][Required] public DateTime RegistrationDate { get; set; }
    [Display(Name = groupNr)][RegularExpression(groupNrEx)] public string? GroupNumber { get; set; }
    [Display(Name = groupStart)][DataType(DataType.Date)] public DateTime StartDate { get; set; }
    [Display(Name = groupEnd)][DataType(DataType.Date)] public DateTime EndDate { get; set; }
    public double? Price { get; set; }
    [Display(Name = Child)][RegularExpression(ChildEx)] public string? ChildName { get; set; }
    [Display(Name = Guardian)][RegularExpression(@GuardianEx)] public string? GuardianName { get; set; }
}