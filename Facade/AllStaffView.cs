using Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Facade;

[DisplayName("All Staff")] public sealed class AllStaffView : AllPersonsView
{
    [Display(Name = "Category")] public int AllCategoriesId { get; set; }
    [Display(Name = "Category")] public string? Category { get; set; }

    // Ametikoht
    private const string emPosition = "Position is required.";
    // Haridustase
    private const string haridustase = "Level of Education";
    private const string emEducation = "Level of Education is required.";
    

    // Ametikoht
    [Required(ErrorMessage = emPosition)] public string? Position { get; set; }

    // Haridustase
    [Required(ErrorMessage = emEducation)]
    [Display(Name = haridustase)]
    public EnumEducation? Education { get; set; }
}
