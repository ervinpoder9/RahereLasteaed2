using Mvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Facade;

public abstract class AllPersonsViewFactory<TData, TView> :
    AbstractViewFactory<TData, TView> where TData : EntityData<TData>, new() where TView : EntityView, new()
{
}
