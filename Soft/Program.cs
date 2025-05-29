using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mvc.Core;
using Mvc.Domain;
using Mvc.Infra;
using Mvc.Soft.Data;
using Mvc.Soft.Models;

internal class Program {
    private static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddControllersWithViews();
        builder.Services.AddTransient<DbContext, ApplicationDbContext>();
        builder.Services.AddTransient<IMoviesRepo, MoviesRepo>();
        builder.Services.AddTransient<IMovieRolesRepo, MovieRolesRepo>();
        builder.Services.AddTransient<IGroupsRepo, GroupsRepo>();
        builder.Services.AddTransient<IFoodAllergiesRepo, FoodAllergiesRepo>();
        builder.Services.AddTransient<ITestingRepo, TestingRepo>();
        builder.Services.AddTransient<IMenusRepo, MenusRepo>();
        builder.Services.AddTransient<IRegistrationsRepo, RegistrationRepo>();
        builder.Services.AddTransient<IAllStaffRepo, AllStaffRepo>();
        builder.Services.AddTransient<IAllCategoriesRepo, AllCategoriesRepo>();
        builder.Services.AddTransient<IChildrenAndRepRepo, ChildrenAndRepRepo>();
        builder.Services.AddTransient<IChildrenRepo, ChildrenRepo>();
        builder.Services.AddTransient<IRepresentativesRepo, RepresentativesRepo>();

        Services.init(builder.Services);
        var app = builder.Build();

        using (var scope = app.Services.CreateScope()) {
            var services = scope.ServiceProvider;
            SeedDataAllCategories.Initialize(services);
        }

        if (app.Environment.IsDevelopment()) {
            app.UseMigrationsEndPoint(); 
            seedData(app);
        } else {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.MapStaticAssets();
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();
        app.MapRazorPages()
            .WithStaticAssets();
        app.Run();
    }
    
    private static void seedData(WebApplication app) {
        Task.Run(async () => {
            IServiceProvider? services = null;
            try {
                using var scope = app.Services.CreateScope();
                services = scope.ServiceProvider;
                var db = services.GetRequiredService<ApplicationDbContext>();
                await new DbInitializer(db).Initialize(5);
            } catch (Exception e) {
                var logger = services?.GetRequiredService<ILogger<Program>>();
                logger?.LogError(e, "An error occurred while seeding the database.");
            }
        });
    }
}
