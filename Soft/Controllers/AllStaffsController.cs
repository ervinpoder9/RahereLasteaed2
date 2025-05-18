using Mvc.Domain;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class AllStaffsController(ApplicationDbContext context) : BaseController<AllStaff>(context)
{ }
