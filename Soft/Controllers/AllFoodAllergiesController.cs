using Mvc.Domain;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class AllFoodAllergiesController(ApplicationDbContext context) : BaseController<AllFoodAllergies>(context)
{}
