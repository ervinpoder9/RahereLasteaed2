using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class MovieRolesController(ApplicationDbContext c)
    : BaseController<MovieRole, MovieRoleData, MovieRoleView>(c, new MovieRoleViewFactory(), d => new(d)) { }
