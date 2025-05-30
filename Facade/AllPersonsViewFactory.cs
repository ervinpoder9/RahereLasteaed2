using Mvc.Data;

namespace Mvc.Facade;

public abstract class AllPersonsViewFactory<TData, TView> :
    AbstractViewFactory<TData, TView> where TData : EntityData<TData>, new() where TView : EntityView, new()
{
}
