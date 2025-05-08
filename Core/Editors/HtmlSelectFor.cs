using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc.Core.Editors;

public static class HtmlSelectFor {
    public static IHtmlContent SelectFor<TModel, TResult>(
        this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> e, SelectList list) 
        => html.ForInput(e, html.DropDownListFor(e, list, new { @class = "form-control" }));
}
