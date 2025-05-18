using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Data;

public sealed class AllCategoriesData : EntityData<AllCategoriesData>
{
    public string? CategoryName { get; set; }
}
