using Microsoft.EntityFrameworkCore;
using Mvc.Data;
using Mvc.Domain;
using Mvc.Soft.Data;

namespace Mvc.Soft.Models
{
    public static class SeedDataAllFoodAllergies
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.AllFoodAllergies.Any())
                {
                    return;
                }
                context.AllFoodAllergies.AddRange(
                    new FoodAllergiesData { AllergyName = "Toidutalumatust ei esine" },
                    new FoodAllergiesData { AllergyName = "Muna" },
                    new FoodAllergiesData { AllergyName = "Gluteen" },
                    new FoodAllergiesData { AllergyName = "Kala" },
                    new FoodAllergiesData { AllergyName = "Piimatooted" },
                    new FoodAllergiesData { AllergyName = "Sojauba" },
                    new FoodAllergiesData { AllergyName = "Pähklid" },
                    new FoodAllergiesData { AllergyName = "Mereannid" }
                );
                context.SaveChanges();
            }
        }
    }
}
