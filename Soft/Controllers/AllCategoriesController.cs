using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class AllCategoriesController(ApplicationDbContext context) 
    : BaseController<AllCategories, AllCategoriesData, AllCategoriesView>
    (context, new AllCategoriesViewFactory(), d => new AllCategories(d))
{ }
