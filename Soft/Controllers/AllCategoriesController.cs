using Mvc.Domain;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class AllCategoriesController(ApplicationDbContext context) : BaseController<AllCategories>(context)
{ }
