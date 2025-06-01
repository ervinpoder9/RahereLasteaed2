using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class AbsencesController(ApplicationDbContext c)
    : BaseController<Absence, AbsenceData, AbsenceView>(c, new AbsenceViewFactory(), d => new(d)) { }
