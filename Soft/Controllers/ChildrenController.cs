using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class ChildrenController(ApplicationDbContext context) 
    : BaseController<ChildrenData, ChildrenView>(context, new ChildrenViewFactory())
{}
