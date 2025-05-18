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
                    new AllFoodAllergiesData { AllergyName = "Toidutalumatust ei esine" },
                    new AllFoodAllergiesData { AllergyName = "Muna" },
                    new AllFoodAllergiesData { AllergyName = "Gluteen" },
                    new AllFoodAllergiesData { AllergyName = "Kala" },
                    new AllFoodAllergiesData { AllergyName = "Piimatooted" },
                    new AllFoodAllergiesData { AllergyName = "Sojauba" },
                    new AllFoodAllergiesData { AllergyName = "Pähklid" },
                    new AllFoodAllergiesData { AllergyName = "Mereannid" }
                );
                context.SaveChanges();
            }
        }
    }
}
