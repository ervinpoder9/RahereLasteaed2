using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers;

public enum EnumRightOfRepresentation
{
    [Description("Esindusõigus seaduse alusel, lapsevanem")]
    LawParent = 0,

    [Description("Esindusõigus kohtuotsuse alusel, lapsevanem")]
    CourtOrderParent = 1,

    [Description("Esindusõigus kohtuotsuse alusel, lapse eestkostja")]
    CourtOrder = 2   
}
