using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class TestingController(ApplicationDbContext c)
    : BaseController<Testing, TestingData, TestingView>(c, new TestingViewFactory(), d => new(d)) { }