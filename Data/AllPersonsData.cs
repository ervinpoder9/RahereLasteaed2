namespace Mvc.Data;

public abstract class AllPersonsData<T> : EntityData<T> where T : EntityData<T> {
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? IDNumber { get; set; }
    public string? Address { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public string? AdditionalInfo { get; set; }
}


