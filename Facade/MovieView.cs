using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mvc.Facade;

[DisplayName("Movie")] public sealed class MovieView : EntityView {
    internal const string relleaseDate = "Release Date";
    internal const string sentenceEx = @"^[A-Z]+[a-zA-Z\s]*$";
    [StringLength(60, MinimumLength = 3), Required] public string? Title { get; set; }
    [Display(Name = relleaseDate), DataType(DataType.Date)] public DateTime ReleaseDate { get; set; }
    [Range(1, 100), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")] public double Price { get; set; }
    [RegularExpression(sentenceEx), Required, StringLength(30)] public string? Genre { get; set; }
    [RegularExpression(sentenceEx), StringLength(5), Required] public string? Rating { get; set; }
}
