﻿namespace Mvc.Domain;

public interface IMoviesRepo : IRepo<Movie>;
public interface IMovieRolesRepo : IRepo<MovieRole>;
public interface IGroupsRepo : IRepo<Group>;
public interface ITestingRepo : IRepo<Testing>;
public interface IRegistrationsRepo : IRepo<Registration>;

public interface IAllStaffRepo : IRepo<AllStaff>;
public interface IAllCategoriesRepo : IRepo<AllCategories>;
public interface IRepo<TObject> {
    public Task<int> PageCount(byte pageSize, string? filter);
    public Task<IEnumerable<TObject>> GetAsync(int pageIdx, byte pageSize
        , string? orderBy = null, string? filter = null);
    public Task<IEnumerable<TObject>> GetAsync(string propertyName, int idValue);
    public Task<IEnumerable<TObject>> GetAsync();
    public Task<TObject?> GetAsync(int? id);
    public Task AddAsync(TObject o);
    public Task UpdateAsync(TObject o);
    public Task DeleteAsync(int id);
}
