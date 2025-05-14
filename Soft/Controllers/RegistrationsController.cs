using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class RegistrationsController(ApplicationDbContext c) : BaseController<Registration, RegistrationData, RegistrationView>
        (c, new RegistrationViewFactory(), d => new (d)) {}
