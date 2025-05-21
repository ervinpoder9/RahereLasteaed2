using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Data;

public sealed class ChildrenAndRepData : EntityData<ChildrenAndRepData>
{
    public int ChildrenId { get; set; }
    public int RepresentativeId { get; set; }
}
