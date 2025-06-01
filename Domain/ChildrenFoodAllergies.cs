using System.ComponentModel;
using System.Reflection.Metadata;
using Helpers;
using Mvc.Core;
using Mvc.Data;

namespace Mvc.Domain;

public class ChildrenFoodAllergies(ChildrenFoodAllergiesData? d) : Entity<ChildrenFoodAllergiesData>(d)
{
    public int ChildrenId => data?.ChildrenId ?? 0;
    public int FoodAllergyId => data?.FoodAllergyId ?? 0;
    public Children? Children => children;
    public FoodAllergies? FoodAllergies => foodAllergies;
    internal Children? children;
    internal FoodAllergies? foodAllergies;
    public override async Task LoadLazy() {
        await base.LoadLazy();
        children = await Services.Get<IChildrenRepo>()?.GetAsync(ChildrenId)!;
        foodAllergies = await Services.Get<IFoodAllergiesRepo>()?.GetAsync(FoodAllergyId)!;
    }
}