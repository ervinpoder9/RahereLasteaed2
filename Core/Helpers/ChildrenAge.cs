using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers;

public static class ChildrenAge
{
    public static int GetAge(string idNumber)
    {
        if (string.IsNullOrEmpty(idNumber))
        {
            throw new InvalidOperationException("Invalid ID Number format.");
        }
        if (idNumber.Length != 11)
        {
            throw new InvalidOperationException("Invalid ID Number length.");
        }

        int centuryIndicator = int.Parse(idNumber.Substring(0, 1));
        int year = int.Parse(idNumber.Substring(1, 2));
        int month = int.Parse(idNumber.Substring(3, 2));
        int day = int.Parse(idNumber.Substring(5, 2));

        int century = centuryIndicator switch
        {
            3 or 4 => 1900,
            5 or 6 => 2000,
            _ => throw new InvalidOperationException("Invalid century indicator in ID Number.")
        };

        DateTime birthDate = new DateTime(century + year, month, day);
        DateTime today = DateTime.Today;

        int age = today.Year - birthDate.Year;
        if (birthDate > today.AddYears(-age)) age--;

        return age;
    }
}
