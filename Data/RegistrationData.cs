namespace Mvc.Data;

public class RegistrationData : EntityData<RegistrationData> {
    public string? RegistrationNumber { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string? GroupNumber { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double? Price { get; set; }
    public string? ChildName { get; set; }
    public string? GuardianName { get; set; }
}