using System.ComponentModel;

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
