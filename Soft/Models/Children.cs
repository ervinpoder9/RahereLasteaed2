using Helpers;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Soft.Models;

public class Children : AllPersons
{
    // Vanus
    [Display(Name = "Vanus")]
    public int Age => IDNumber != null ? ChildrenAge.GetAge(IDNumber) : 0;
}
