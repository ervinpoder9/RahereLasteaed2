using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace Mvc.Facade;

[DisplayName("Children And Reperesentative")] public sealed class ChildrenAndRepView : EntityView
{
    [Display(Name = "Child")] public int ChildId { get; set; }
    [Display(Name = "Lapse nimi")] public string? ChildName { get; set; }
    [Display(Name = "Lapse perekonnanimi")] public string? ChildSurname { get; set; }

    [Display(Name = "Representative")] public int RepresentativeId { get; set; }
    [Display(Name = "Esindaja nimi")] public string? RepresentativeName { get; set; }
    [Display(Name = "Esindaja perekonnanimi")] public string? RepresentativeSurname { get; set; }



    // Esindusõigus
    private const string esindusOigus = "Right Of Representation";
    private const string emRight = "Right Of Representation is required.";

    [Required(ErrorMessage = emRight)]
    [Display(Name = esindusOigus)]
    public EnumRightOfRepresentation RightOfRepresentation { get; set; }

    // Muu info
    private const string lisainfo = "Additional Info";
    [Display(Name = lisainfo)] public string? AdditionalInfo { get; set; }
}


