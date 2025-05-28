using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class FoodAllergiesController(ApplicationDbContext c) 
    : BaseController<FoodAllergies, FoodAllergiesData, FoodAllergiesView>
    (c, new FoodAllergiesViewFactory(), d => new (d)) { }

