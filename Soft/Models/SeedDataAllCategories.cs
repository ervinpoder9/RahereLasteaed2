using Microsoft.EntityFrameworkCore;
using Mvc.Data;
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
                new AllCategoriesData { CategoryName = "Õpetajad" },
                new AllCategoriesData { CategoryName = "Õpetaja assistendid" },
                new AllCategoriesData { CategoryName = "Aineõpetajad" },
                new AllCategoriesData { CategoryName = "Juhtkond" },
                new AllCategoriesData { CategoryName = "Tugikeskus" }
                );
            context.SaveChanges();
        }
    }
}
