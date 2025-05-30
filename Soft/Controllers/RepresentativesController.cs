using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class RepresentativesController(ApplicationDbContext context) 
    : BaseController<Representative, RepresentativeData, RepresentativeView>
    (context, new RepresentativeViewFactory(), d => new Representative(d))
{ }
