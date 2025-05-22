using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class AllStaffsController(ApplicationDbContext context) 
    : BaseController<AllStaff, AllStaffData, AllStaffView>
    (context, new AllStaffViewFactory(), d => new AllStaff(d))
{ }
