using Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Mvc.Core;
using Mvc.Domain;

namespace Mvc.Facade;

[DisplayName("Children")] public sealed class ChildrenFoodAllergiesView : EntityView {
    [DisplayName("Child")] public int ChildrenId { get; set; }
    [DisplayName("Food Allergy")]public int FoodAllergyId { get; set; }
    [DisplayName("Child")] public string? Children {
        get {
            if (!string.IsNullOrEmpty(_children))
                return _children;
            if (this.ChildrenId > 0)
                return Services.Get<IChildrenRepo>()?.GetAsync(ChildrenId)?.Result?.Name + " " + Services.Get<IChildrenRepo>()?.GetAsync(ChildrenId)?.Result?.Surname;
            return null;
        }
        set => _children = value;
    }

    [DisplayName("Food Allergy")]public string? FoodAllergy {
        get {
            if (!string.IsNullOrEmpty(_foodAllergy))
                return _foodAllergy;
            if (this.FoodAllergyId > 0)
                return Services.Get<IFoodAllergiesRepo>()?.GetAsync(FoodAllergyId)?.Result?.AllergyName;
            return null;
        }
        set => _foodAllergy = value;
    }
    private string? _foodAllergy;
    private string? _children;
}
