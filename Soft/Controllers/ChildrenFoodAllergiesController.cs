using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class ChildrenFoodAllergiesController(ApplicationDbContext context) 
    : BaseController<ChildrenFoodAllergies, ChildrenFoodAllergiesData, ChildrenFoodAllergiesView>
    (context, new ChildrenFoodAllergiesViewFactory(), d => new ChildrenFoodAllergies(d))
{ }
