using Microsoft.AspNetCore.Mvc;
using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Infra;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class ChildrenAndRepController(ApplicationDbContext context) 
    : BaseController<ChildrenAndRep, ChildrenAndRepData, ChildrenAndRepView>
    (context, new ChildrenAndRepViewFactory(), d => new ChildrenAndRep(d))
{
    //Если метод не помечен как virtual, то можно просто скрыть его с помощью new.
    //Лучше использовать override, но если такой возможности нет, то new подойдёт.

    // 1. Передаём параметры от браузера:
    // Получаем параметры от пользователя: страница, сортировка, фильтр и выбранный элемент.

    [HttpGet]
    [Route("ChildrenAndRep")]
    [Route("ChildrenAndRep/Index")]
    public new async Task<IActionResult> Index(int pageIdx = 0, string? orderBy = null,
        string? filter = null, int? selectedId = null)
    {
        //2.Сохраняем параметры во ViewBag:
        //ViewBag позволяет передать эти значения в Razor-шаблон Index.cshtml (например, для пагинации).

        ViewBag.PageIdx = pageIdx;
        ViewBag.PageCount = await GetPageCount(filter);
        ViewBag.OrderBy = orderBy;
        ViewBag.Filter = filter;
        ViewBag.SelectedId = selectedId;

        // 3. Получаем список объектов из базы:
        // Создаём репозиторий ChildrenAndRep.
        // Получаем список из базы с учётом фильтрации, сортировки и постраничного отображения.
        var repo = new Repo<ChildrenAndRep, ChildrenAndRepData>(context, d => new ChildrenAndRep(d));
        var oList = await repo.GetAsync(pageIdx, 10, orderBy, filter);

        // 4. Создаём список View-моделей с подгрузкой имён
        /*
         Здесь происходит главное:
            Для каждой записи создаём ChildrenAndRepView через CreateView(...).
            Так как loadLazy: true, в фабрике вызывается метод LoadLazy(), который:
            Загружает Children по ChildrenId;
            Загружает Representative по RepresentativeId;
            Собирает имя и фамилию для обоих в ChildFullName и RepresentativeFullName.
         */
        var factory = new ChildrenAndRepViewFactory();
        var vList = new List<ChildrenAndRepView>();

        foreach (var obj in oList)
        {
            var view = await factory.CreateView(obj?.data, loadLazy: true);
            vList.Add(view);
        }
        // 5. Отдаём результат в Razor-шаблон
        return View(vList);
    }

    // 6. Метод для расчёта количества страниц
    // Используется, чтобы правильно отобразить постраничную навигацию (pagination) — сколько всего страниц.
    private async Task<int> GetPageCount(string? filter)
    {
        var repo = new Repo<ChildrenAndRep, ChildrenAndRepData>(context, d => new ChildrenAndRep(d));
        return await repo.PageCount(10, filter);
    }

    private readonly ApplicationDbContext context = context;
}

