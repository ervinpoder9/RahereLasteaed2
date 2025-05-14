using Mvc.Data;

namespace Mvc.Domain;

public class Registration(RegistrationData d) : Entity<RegistrationData>(d) {
    public string? RegistrationNumber => data?.RegistrationNumber;
    public DateTime? RegistrationDate => data?.RegistrationDate;
    public string? GroupNumber => data?.GroupNumber;
    public DateTime? StartDate => data?.StartDate;
    public DateTime? EndDate => data?.EndDate;
    public double? Price => data?.Price;
    public string? ChildName => data?.ChildName;
    public string? GuardianName => data?.GuardianName;
}