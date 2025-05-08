using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace Mvc.Core.Editors;

public static class HtmlShowFor {
    public static IHtmlContent ShowFor<TModel, TResult>(
        this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> e)
        => html.ForShow(e, html.DisplayFor(e));
}

