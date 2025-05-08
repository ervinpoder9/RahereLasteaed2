using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class MoviesController(ApplicationDbContext c) 
    : BaseController<Movie, MovieData, MovieView>(c, new MovieViewFactory(), d => new(d)) { }
