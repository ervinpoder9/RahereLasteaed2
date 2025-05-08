using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc.Core.Editors;

public static class HtmlInputFor {
    public static IHtmlContent InputFor<TModel, TResult>(
        this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> e) 
        => html.ForInput(e, html.EditorFor(e, new { htmlAttributes = new { @class = "form-control" } }));
}

