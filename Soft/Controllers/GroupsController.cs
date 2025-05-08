using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class GroupsController(ApplicationDbContext c) 
    : BaseController<Group, GroupData, GroupView>(c, new GroupViewFactory(), d => new(d)) { }
