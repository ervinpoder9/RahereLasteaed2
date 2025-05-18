using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Facade;

[DisplayName("All Categories")] public sealed class AllCategoriesView : EntityView
{
    public string? CategoryName { get; set; }
}
