using Microsoft.AspNetCore.Mvc;
using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Infra;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class AllStaffsController(ApplicationDbContext context) 
    : BaseController<AllStaff, AllStaffData, AllStaffView>
    (context, new AllStaffViewFactory(), d => new AllStaff(d))
{
    [HttpGet]
    [Route("AllStaffRep")]
    [Route("AllStaffRep/Index")]
    public new async Task<IActionResult> Index(int pageIdx = 0, string? orderBy = null,
        string? filter = null, int? selectedId = null)
    {
        ViewBag.PageIdx = pageIdx;
        ViewBag.PageCount = await GetPageCount(filter);
        ViewBag.OrderBy = orderBy;
        ViewBag.Filter = filter;
        ViewBag.SelectedId = selectedId;

        var repo = new Repo<AllStaff, AllStaffData>(context, d => new AllStaff(d));
        var oList = await repo.GetAsync(pageIdx, 10, orderBy, filter);


        var factory = new AllStaffViewFactory();
        var vList = new List<AllStaffView>();

        foreach (var obj in oList)
        {
            var view = await factory.CreateView(obj?.data, loadLazy: true);
            vList.Add(view);
        }
        return View(vList);
    }

    private async Task<int> GetPageCount(string? filter)
    {
        var repo = new Repo<ChildrenAndRep, ChildrenAndRepData>(context, d => new ChildrenAndRep(d));
        return await repo.PageCount(10, filter);
    }

    private readonly ApplicationDbContext context = context;
}
