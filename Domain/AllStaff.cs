using Helpers;
using Mvc.Data;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Domain;

public class AllStaff(AllStaffData d) : AllPersons<AllStaffData>(d)
{
    public int CategoryId => data?.CategoryId ?? 0;
    public AllCategories? Category => category;
    internal AllCategories? category;

    public string? Position => data?.Position;
    public EnumEducation? Education => data?.Education;  
}

