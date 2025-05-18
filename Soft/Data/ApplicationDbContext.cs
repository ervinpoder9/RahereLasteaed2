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

public DbSet<AllCategories> AllCategories { get; set; } = default!;

public DbSet<AllFoodAllergies> AllFoodAllergies { get; set; } = default!;

public DbSet<AllStaff> AllStaff { get; set; } = default!;

public DbSet<Children> Children { get; set; } = default!;

public DbSet<Representative> Representative { get; set; } = default!;
}
