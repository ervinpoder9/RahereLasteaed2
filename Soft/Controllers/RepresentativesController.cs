using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class RepresentativesController(ApplicationDbContext context) 
    : BaseController<RepresentativeData, RepresentativeView>(context, new RepresentativeViewFactory)
{}
