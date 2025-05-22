using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class ChildrenController(ApplicationDbContext context) 
    : BaseController<Children, ChildrenData, ChildrenView>
    (context, new ChildrenViewFactory(), d => new Children(d))
{ }
