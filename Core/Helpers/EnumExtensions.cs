using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Core.Helpers;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        if (value == null) return string.Empty;

        var type = value.GetType();
        var memberInfo = type.GetMember(value.ToString());
        var attribute = memberInfo.FirstOrDefault()?
            .GetCustomAttribute<DescriptionAttribute>();

        return attribute?.Description ?? value.ToString();
    }
}
