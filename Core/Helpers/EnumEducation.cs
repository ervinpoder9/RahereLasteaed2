using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers;

public enum EnumEducation
{
    [Description("Põhiharidus")]
    PrimaryEducation = 0,

    [Description("Keskharidus")]
    SecondaryEducation = 1,

    [Description("Kutseharidus")]
    VocationalEducation = 2,

    [Description("Rakenduskõrgharidus")]
    AppliedHigherEducation = 3,

    [Description("Bakalaureuse kraat")]
    BachelorsDegree = 4,

    [Description("Magistrikraat")]
    MastersDegree = 5,

    [Description("Doktorikraat")]
    DoctoralDegree = 6
}
