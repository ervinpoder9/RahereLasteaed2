using Microsoft.EntityFrameworkCore;
using Mvc.Domain;
using Mvc.Soft.Data;

namespace Mvc.Soft.Models;

public static class SeedDataAllCategories
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>()))
        {
            if (context.AllCategories.Any())
            {
                return;   
            }
            context.AllCategories.AddRange(
                new AllCategories { CategoryName = "Õpetajad" },
                new AllCategories { CategoryName = "Õpetaja assistendid" },
                new AllCategories { CategoryName = "Aineõpetajad" },
                new AllCategories { CategoryName = "Juhtkond" },
                new AllCategories { CategoryName = "Tugikeskus" }
                );
            context.SaveChanges();
        }
    }
}
