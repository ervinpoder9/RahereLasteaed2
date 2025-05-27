using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Facade;

[DisplayName("All Categories")] public sealed class AllCategoriesView : EntityView
{
    [Display(Name = "CategoryName")] public string? CategoryName { get; set; }
}
