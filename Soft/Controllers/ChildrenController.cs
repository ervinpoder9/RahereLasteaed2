using Mvc.Domain;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class ChildrenController(ApplicationDbContext context) : BaseController<Children>(context)
{}
