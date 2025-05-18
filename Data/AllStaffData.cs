using Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Data;

public sealed class AllStaffData : AllPersonsData<AllStaffData>
{
    public string? Position { get; set; }
    public EnumEducation? Education { get; set; }
}

