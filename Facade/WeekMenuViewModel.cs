namespace Mvc.Facade;

public class WeekMenuViewModel
{
    public DateTime WeekStartDate { get; set; }
    public List<MenuView> DailyMenus { get; set; } = new();

    // Abimeetodid päevade jaoks
    public MenuView Monday => DailyMenus[0];
    public MenuView Tuesday => DailyMenus[1];
    public MenuView Wednesday => DailyMenus[2];
    public MenuView Thursday => DailyMenus[3];
    public MenuView Friday => DailyMenus[4];
}