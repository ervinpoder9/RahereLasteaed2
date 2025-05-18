using Microsoft.EntityFrameworkCore;
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
                    new AllFoodAllergies { AllergyName = "Toidutalumatust ei esine" },
                    new AllFoodAllergies { AllergyName = "Muna" },
                    new AllFoodAllergies { AllergyName = "Gluteen" },
                    new AllFoodAllergies { AllergyName = "Kala" },
                    new AllFoodAllergies { AllergyName = "Piimatooted" },
                    new AllFoodAllergies { AllergyName = "Sojauba" },
                    new AllFoodAllergies { AllergyName = "Pähklid" },
                    new AllFoodAllergies { AllergyName = "Mereannid" }
                );
                context.SaveChanges();
            }
        }
    }
}
