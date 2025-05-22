using Mvc.Data;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Domain;
public abstract class AllPersons<T>(T? d) : Entity<T>(d) where T : AllPersonsData<T>
{
    public string? Name => data?.Name;
    public string? Surname => data?.Surname;
    public string? IDNumber => data?.IDNumber;
    public string? Address => data?.Address;
    public string? Mobile => data?.Mobile;
    public string? Email => data?.Email;
    public string? AdditionalInfo => data?.AdditionalInfo;
}
