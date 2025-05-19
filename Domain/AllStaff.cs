using Helpers;
using Mvc.Data;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Domain;

public class AllStaff(AllStaffData d) : AllPersons<AllStaffData>(d)
{    
    // Ametikoht
    public string? Position => data?.Position;

    // Haridustase
    public EnumEducation? Education => data?.Education;
}

