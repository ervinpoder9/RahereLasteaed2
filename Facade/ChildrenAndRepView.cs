using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Helpers;

namespace Mvc.Facade;

[DisplayName("Children and Reperesentatives")] public sealed class ChildrenAndRepView : EntityView
{
    [Display(Name = "Child")] public int ChildId { get; set; }
    [Display(Name = "Representative")] public int RepresentativeId { get; set; }


    [Display(Name = "Child's Full Name")] public string? ChildFullName { get; set; }
    [Display(Name = "Representative's Full Name")] public string? RepresentativeFullName { get; set; }



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


