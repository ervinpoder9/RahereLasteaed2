using Microsoft.AspNetCore.Mvc;
using Mvc.Data;
using Mvc.Domain;
using Mvc.Facade;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers;

public class MenusController(ApplicationDbContext c) : Controller
{
    private readonly ApplicationDbContext _context = c;
    private readonly MenuViewFactory _factory = new();

    // Näita nädalavaadet - see on vaikimisi leht
    public async Task<IActionResult> Index(DateTime? weekStart)
    {
        // Võta käesoleva nädala algus, kui pole määratud
        weekStart ??= GetWeekStart(DateTime.Today);
        var weekEnd = weekStart.Value.AddDays(5);

        // Leia selle nädala menüüd
        var menus = _context.Menus
            .Where(m => m.Date >= weekStart && m.Date < weekEnd)
            .OrderBy(m => m.Date)
            .ToList();

        var viewModel = new WeekMenuViewModel
        {
            WeekStartDate = weekStart.Value,
            DailyMenus = new List<MenuView>()
        };

        // Lisa kõik päevad, isegi kui menüü puudub
        for (int i = 0; i < 5; i++)
        {
            var date = weekStart.Value.AddDays(i);
            var menu = menus.FirstOrDefault(m => m.Date.Date == date.Date);

            if (menu != null)
            {
                viewModel.DailyMenus.Add(_factory.CreateView(menu));
            }
            else
            {
                viewModel.DailyMenus.Add(new MenuView { Date = date });
            }
        }

        return View(viewModel);
    }

    // Muuda kindla päeva menüüd
    public async Task<IActionResult> EditDay(DateTime date)
    {
        // Otsi olemasolev menüü või loo uus
        var existingMenu = _context.Menus
            .FirstOrDefault(m => m.Date.Date == date.Date);

        MenuView view;
        if (existingMenu != null)
        {
            view = _factory.CreateView(existingMenu);
        }
        else
        {
            // Loo uus menüü
            view = new MenuView
            {
                Date = date
            };
        }

        ViewBag.DayName = GetEstonianDayName(date.DayOfWeek);
        ViewBag.WeekStart = GetWeekStart(date);

        return View(view);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditDay(MenuView view)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.DayName = GetEstonianDayName(view.Date.DayOfWeek);
            ViewBag.WeekStart = GetWeekStart(view.Date);
            return View(view);
        }

        var data = _factory.CreateData(view);
        var existingMenu = _context.Menus
            .FirstOrDefault(m => m.Date.Date == view.Date.Date);

        if (existingMenu != null)
        {
            // Uuenda olemasolevat
            existingMenu.Breakfast = data.Breakfast;
            existingMenu.Lunch = data.Lunch;
            existingMenu.Snack = data.Snack;
            existingMenu.Notes = data.Notes;
            _context.Update(existingMenu);
        }
        else
        {
            // Lisa uus
            _context.Add(data);
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index), new { weekStart = GetWeekStart(view.Date) });
    }

    // Abimeetodid
    private DateTime GetWeekStart(DateTime date)
    {
        int diff = (int)date.DayOfWeek - (int)DayOfWeek.Monday;
        if (diff < 0) diff += 7;
        return date.AddDays(-diff).Date;
    }

    private string GetEstonianDayName(DayOfWeek day)
    {
        return day switch
        {
            DayOfWeek.Monday => "Esmaspäev",
            DayOfWeek.Tuesday => "Teisipäev",
            DayOfWeek.Wednesday => "Kolmapäev",
            DayOfWeek.Thursday => "Neljapäev",
            DayOfWeek.Friday => "Reede",
            _ => day.ToString()
        };
    }
}