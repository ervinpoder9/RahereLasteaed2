using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mvc.Data;
using Mvc.Soft.Data;

namespace Mvc.Tests.Soft.Data;

[TestClass] public class ApplicationDbContextTests 
    : BaseClassTests<ApplicationDbContext, IdentityDbContext> {
    protected override ApplicationDbContext createObj() {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options);
    }
    [TestMethod] public void MoviesTest() => isType(obj!.Movies, typeof(DbSet<MovieData>));
    [TestMethod] public void MovieRolesTest() => isType(obj!.MovieRoles, typeof(DbSet<MovieRoleData>));
    [TestMethod] public void TestsTest() => isType(obj!.Tests, typeof(DbSet<TestingData>));
    [TestMethod] public void GroupsTest() => isType(obj!.Groups, typeof(DbSet<GroupData>));
    [TestMethod] public void FoodAllergiesTest() => isType(obj!.FoodAllergies, typeof(DbSet<FoodAllergiesData>));
}
