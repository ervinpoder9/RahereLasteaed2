using Mvc.Data;

namespace Mvc.Domain;

public sealed class Menu(MenuData? d) : Entity<MenuData>(d)
{
    public DateTime Date => data?.Date ?? DateTime.Now;
    public string? Breakfast => data?.Breakfast;
    public string? Lunch => data?.Lunch;
    public string? Snack => data?.Snack;
    public string? Notes => data?.Notes;
}