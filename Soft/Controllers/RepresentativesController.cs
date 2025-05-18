using Mvc.Domain;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class RepresentativesController(ApplicationDbContext context) : BaseController<Representative>(context)
{}
