using Mvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Domain;

public class ChildrenAndRep(ChildrenAndRepData d) : Entity<ChildrenAndRepData>(d)
{
    public int ChildrenId => data?.ChildrenId ?? 0;
    public int RepresentativeId => data?.RepresentativeId ?? 0;
}
