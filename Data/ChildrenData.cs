using Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Data;

public sealed class ChildrenData : AllPersonsData<ChildrenData>
{
    public int Age => IDNumber != null ? ChildrenAge.GetAge(IDNumber) : 0;
}
