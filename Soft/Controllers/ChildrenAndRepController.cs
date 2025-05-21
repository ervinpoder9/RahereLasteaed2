using Microsoft.AspNetCore.Mvc;
using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class ChildrenAndRepController(ApplicationDbContext context) 
    : BaseController<ChildrenAndRep, ChildrenAndRepData, ChildrenAndRepView>
    (context, new ChildrenAndRepViewFactory(), d => new ChildrenAndRep(d))
{ }

