using Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Data;

public sealed class RepresentativeData : AllPersonsData<RepresentativeData>
{
    public EnumRightOfRepresentation RightOfRepresentation { get; set; }
}
