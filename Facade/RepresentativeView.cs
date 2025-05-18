using Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Facade;

[DisplayName("Representative")] public sealed class RepresentativeView : AllPersonsView
{
    // Esindusõigus
    private const string esindusOigus = "Esindusõigus";
    private const string emRight = "Right Of Representation is required.";

    
    // Esindusõigus
    [Required(ErrorMessage = emRight)]
    [Display(Name = esindusOigus)]
    public EnumRightOfRepresentation RightOfRepresentation { get; set; }
}
