using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Mvc.Data;
using Mvc.Domain;

namespace Mvc.Infra;

public sealed class MoviesRepo(DbContext db)
    : Repo<Movie, MovieData>(db, d => new(d)), IMoviesRepo { }
public sealed class MovieRolesRepo(DbContext db)
    : Repo<MovieRole, MovieRoleData>(db, d => new(d)), IMovieRolesRepo { }
public sealed class GroupsRepo(DbContext db)
    : Repo<Group, GroupData>(db, d => new(d)), IGroupsRepo { }
public sealed class TestingRepo(DbContext db)
    : Repo<Testing, TestingData>(db, d => new(d)), ITestingRepo { }
public sealed class RegistrationRepo(DbContext db)
    : Repo<Registration, RegistrationData>(db, d => new(d)), IRegistrationsRepo {}

public sealed class AllCategoriesRepo(DbContext db)
    : Repo<AllCategories, AllCategoriesData>(db, d => new(d)), IAllCategoriesRepo
{ }
public sealed class AllStaffRepo(DbContext db)
    : Repo<AllStaff, AllStaffData>(db, d => new(d)), IAllStaffRepo
{ }

public sealed class ChildrenAndRepRepo(DbContext db)
: Repo<ChildrenAndRep, ChildrenAndRepData>(db, d => new(d)), IChildrenAndRepRepo
{ }

public sealed class ChildrenRepo(DbContext db)
: Repo<Children, ChildrenData>(db, d => new(d)), IChildrenRepo
{ }
public sealed class RepresentativesRepo(DbContext db)
: Repo<Representative, RepresentativeData>(db, d => new(d)), IRepresentativesRepo
{ }



public class Repo<TObject, TData>(DbContext c, Func<TData?, TObject> f)
    : IRepo<TObject> where TObject : Entity<TData> where TData : EntityData<TData> {
    private readonly DbContext db = c;
    private readonly DbSet<TData> set = c.Set<TData>();
    private static bool isAsc(string s) => !s.EndsWith("_desc");
    private static string propName(string s) => s.Replace("_desc", "");
    private ParsingConfig config = new ParsingConfig { AllowEqualsAndToStringMethodsOnObject = true };
    private IQueryable<TData> ordered(string? orderBy = null, string? filter = null)
        => (orderBy is null) ? filtered(filter) : isAsc(orderBy)
            ? filtered(filter).OrderBy(propName(orderBy))
            : filtered(filter).OrderBy(propName(orderBy) + " descending");
    private IQueryable<TData> filtered(string? filter = null)
        => (filter is null) ? set : set.Where(config, whereExpr(), filter);
    private IQueryable<TData> filtered(string propertyName, int idValue)
        => set.Where(whereExpr(propertyName), idValue);
    private string whereExpr(string propertyName) {
        var filters = new List<string>();
        foreach (var p in typeof(TData).GetProperties()) {
            if (p.Name != propertyName)
                continue;
            if (p.PropertyType != typeof(int))
                continue;
            filters.Add($"({p.Name}==@0)");
        }
        return string.Join(" OR ", filters);
    }
    private string whereExpr() {
        var filters = new List<string>();
        foreach (var p in typeof(TData).GetProperties()) {
            if (p.PropertyType == typeof(string)) filters.Add($"({p.Name} != null && {p.Name}.Contains(@0))");
            else if (p.PropertyType == typeof(DateTime)) filters.Add($"({p.Name}.ToString().Contains(@0))");
            else if (p.PropertyType == typeof(char)) filters.Add($"({p.Name}.ToString().Contains(@0))");
            else if (p.PropertyType == typeof(bool)) filters.Add($"({p.Name}.ToString().Contains(@0))");
            else if (p.PropertyType == typeof(byte)) filters.Add($"({p.Name}.ToString().Contains(@0))");
            else if (p.PropertyType == typeof(short)) filters.Add($"({p.Name}.ToString().Contains(@0))");
            //else if (p.PropertyType == typeof(int)) filters.Add($"({p.Name}.ToString().Contains(@0))");
            else if (p.PropertyType == typeof(long)) filters.Add($"({p.Name}.ToString().Contains(@0))");
            else if (p.PropertyType == typeof(sbyte)) filters.Add($"({p.Name}.ToString().Contains(@0))");
            else if (p.PropertyType == typeof(ushort)) filters.Add($"({p.Name}.ToString().Contains(@0))");
            else if (p.PropertyType == typeof(uint)) filters.Add($"({p.Name}.ToString().Contains(@0))");
            else if (p.PropertyType == typeof(ulong)) filters.Add($"({p.Name}.ToString().Contains(@0))");
            else if (p.PropertyType == typeof(double)) filters.Add($"({p.Name}.ToString().Contains(@0))");
            else if (p.PropertyType == typeof(float)) filters.Add($"({p.Name}.ToString().Contains(@0))");
            else if (p.PropertyType == typeof(decimal)) filters.Add($"({p.Name}.ToString().Contains(@0))");
        }
        return string.Join(" OR ", filters);
    }
    public async Task<int> PageCount(byte pageSize, string? filter) {
        var cnt = await filtered(filter).CountAsync();
        return cnt % pageSize == 0 ? cnt / pageSize : cnt / pageSize + 1;
    }
    public async Task<IEnumerable<TObject>> GetAsync(string propertyName, int idValue)
        => (await filtered(propertyName, idValue).ToListAsync()).Select(f);
    public async Task<IEnumerable<TObject>> GetAsync(int pageIdx, byte pageSize, 
        string? orderBy = null, string? filter = null)
        => (await ordered(orderBy, filter)
            .Skip(pageIdx * pageSize).Take(pageSize).ToListAsync()).Select(f);
    public async Task<IEnumerable<TObject>> GetAsync() => (await set.ToListAsync()).Select(f);
    public async Task<TObject?> GetAsync(int? id) => (id is null) ? null : f(await set.FindAsync(id));
    public async Task AddAsync(TObject o) {
        var d = o?.data;
        if (d is null)
            return;
        set.Add(d);
        await db.SaveChangesAsync();
    }
    public async Task UpdateAsync(TObject o) {
        var d = o?.data;
        if (d is null)
            return;
        set.Update(d);
        await db.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id) {
        var x = await set.FindAsync(id);
        if (x is null)
            return;
        set.Remove(x);
        await db.SaveChangesAsync();
    }
}