using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers;

public enum EnumRightOfRepresentation
{
    [Description("Law, Parent")]
    LawParent = 0,

    [Description("Court Order, Parent")]
    CourtOrderParent = 1,

    [Description("Court Order, Guardian")]
    CourtOrder = 2   
}
