using Helpers;
using Mvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Domain;

public class ChildrenAndRep(ChildrenAndRepData d) : Entity<ChildrenAndRepData>(d)
{
    public int ChildrenId => data?.ChildId ?? 0;
    public int RepresentativeId => data?.RepresentativeId ?? 0;

    // Esindusõigus
    public EnumRightOfRepresentation? RightOfRepresentation => data?.RightOfRepresentation;

    // Muu oluline info
    public string? AdditionalInfo => data?.AdditionalInfo;


}
