using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mvc.Data;
using Mvc.Domain;

namespace Mvc.Soft.Data;

public class ApplicationDbContext : IdentityDbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<MovieData> Movies { get; set; } = default!;
    public DbSet<MovieRoleData> MovieRoles { get; set; } = default!;
    public DbSet<GroupData> Groups { get; set; } = default!;
    public DbSet<RegistrationData> Registrations { get; set; } = default!;
    public DbSet<TestingData> Tests { get; set; } = default!;
    public DbSet<AllCategoriesData> AllCategories { get; set; } = default!;
    public DbSet<FoodAllergiesData> AllFoodAllergies { get; set; } = default!;
    public DbSet<AllStaffData> AllStaff { get; set; } = default!;
    public DbSet<ChildrenData> Children { get; set; } = default!;
    public DbSet<RepresentativeData> Representative { get; set; } = default!;
    public DbSet<ChildrenAndRepData> ChildrenAndRep { get; set; } = default!;

    public DbSet<MenuData> Menus { get; set; } = default!;
}
