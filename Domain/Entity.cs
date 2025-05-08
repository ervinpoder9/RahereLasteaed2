using Mvc.Data;

namespace Mvc.Domain;

public abstract class Entity<TData>(TData? d) where TData : EntityData<TData> {
    public TData? data { get; } = d?.Clone();
    public int? Id => data?.Id;
    public virtual async Task LoadLazy() => await Task.CompletedTask;
}
