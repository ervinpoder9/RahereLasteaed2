using Mvc.Data;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Domain;
public abstract class AllPersons<T>(T? d) : Entity<T>(d) where T : AllPersonsData<T>
{
    // Eesnimi
    public string? Name => data?.Name;
    // Perekonnanimi
    public string? Surname => data?.Surname;
    // Isikukood
    public string? IDNumber => data?.IDNumber;
    // Aadress
    public string? Address => data?.Address;
    // Telefoninumber
    public string? Mobile => data?.Mobile;
    // E-mail
    public string? Email => data?.Email;
}
