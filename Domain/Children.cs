using Helpers;
using Mvc.Data;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Domain;

public class Children(ChildrenData d) : AllPersons<ChildrenData>(d)
{
    public int Age => data?.IDNumber != null ? ChildrenAge.GetAge(data.IDNumber) : 0;
}
