using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mvc.Data;
using Mvc.Soft.Models;

namespace Mvc.Soft.Data;

public class ApplicationDbContext : IdentityDbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<MovieData> Movies { get; set; } = default!;
    public DbSet<MovieRoleData> MovieRoles { get; set; } = default!;
    public DbSet<GroupData> Groups { get; set; } = default!;
    public DbSet<RegistrationData> Registrations { get; set; } = default!;
    public DbSet<TestingData> Tests { get; set; } = default!;

public DbSet<Mvc.Soft.Models.AllCategories> AllCategories { get; set; } = default!;

public DbSet<Mvc.Soft.Models.AllFoodAllergies> AllFoodAllergies { get; set; } = default!;

public DbSet<Mvc.Soft.Models.AllStaff> AllStaff { get; set; } = default!;

public DbSet<Mvc.Soft.Models.Children> Children { get; set; } = default!;

public DbSet<Mvc.Soft.Models.Representative> Representative { get; set; } = default!;
}
