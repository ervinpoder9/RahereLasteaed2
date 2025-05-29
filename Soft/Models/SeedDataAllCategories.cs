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
                new AllCategoriesData { CategoryName = "Teachers" },
                new AllCategoriesData { CategoryName = "Teacher's Assistants" },
                new AllCategoriesData { CategoryName = "Subject Teachers" },
                new AllCategoriesData { CategoryName = "Administration" },
                new AllCategoriesData { CategoryName = "Support Center" }
                );
            context.SaveChanges();
        }
    }
}
