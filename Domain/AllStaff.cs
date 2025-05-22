using Helpers;
using Mvc.Data;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Domain;

public class AllStaff(AllStaffData d) : AllPersons<AllStaffData>(d)
{
    public int AllCategoriesId => data?.AllCategoriesId ?? 0;
    public string? Position => data?.Position;
    public EnumEducation? Education => data?.Education;  
}

