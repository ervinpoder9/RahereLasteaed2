using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class AllCategoriesController(ApplicationDbContext context) 
    : BaseController<AllCategoriesData, AllCategoriesView>(context, new AllCategoriesViewFactory())
{ }
