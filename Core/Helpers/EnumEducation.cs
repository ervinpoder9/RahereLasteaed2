using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers;

public enum EnumEducation
{
    [Description("Basic Education")]
    PrimaryEducation = 0,

    [Description("General Secondary Education")]
    SecondaryEducation = 1,

    [Description("Vocational Education")]
    VocationalEducation = 2,

    [Description("Professional Higher Education")]
    AppliedHigherEducation = 3,

    [Description("Bachelor's degree")]
    BachelorsDegree = 4,

    [Description("Master's degree")]
    MastersDegree = 5,

    [Description("Doctoral degrees")]
    DoctoralDegree = 6
}
