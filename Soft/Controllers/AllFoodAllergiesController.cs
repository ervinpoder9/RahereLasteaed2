using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class AllFoodAllergiesController(ApplicationDbContext context) 
    : BaseController<AllFoodAllergies, AllFoodAllergiesData, AllFoodAllergiesView>
    (context, new AllFoodAllergiesViewFactory(), d => new AllFoodAllergies(d))
{ }

