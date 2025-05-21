using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Facade;

[DisplayName("Children And Reperesentative")] public sealed class ChildrenAndRepView : EntityView
{
    [Display(Name = "Laps")] public int ChildId { get; set; }
    [Display(Name = "Lapse")] public string? ChildName { get; set; }
    [Display(Name = "Esindaja")] public int RepresentativeId { get; set; }
    [Display(Name = "Esindaja")] public string? RepresentativeName { get; set; }
}


