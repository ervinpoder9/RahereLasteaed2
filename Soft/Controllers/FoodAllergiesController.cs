using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class FoodAllergiesController(ApplicationDbContext context) 
    : BaseController<FoodAllergies, FoodAllergiesData, FoodAllergiesView>
    (context, new FoodAllergiesViewFactory(), d => new FoodAllergies(d)) { }

