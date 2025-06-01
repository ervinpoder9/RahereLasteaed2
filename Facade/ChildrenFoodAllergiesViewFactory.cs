using Mvc.Data;
using Mvc.Domain;

namespace Mvc.Facade;

public sealed class
    ChildrenFoodAllergiesViewFactory : AbstractViewFactory<ChildrenFoodAllergiesData, ChildrenFoodAllergiesView> {

    public override async Task<ChildrenFoodAllergiesView> CreateView(ChildrenFoodAllergiesData? d, bool loadLazy = false)
    {
        var v = await base.CreateView(d, loadLazy);
        if (!loadLazy) return v;
        var o = new ChildrenFoodAllergies(d);
        await o.LoadLazy();
        v.Children = o.Children?.Name + " " + o.Children?.Surname;
        v.FoodAllergy = o.FoodAllergies?.AllergyName;
        return v;
    }
}
