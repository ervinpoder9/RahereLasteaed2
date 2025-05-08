using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc.Core.Editors;

public static class HtmlForInput {
    public static IHtmlContent ForInput<TModel, TResult>(
        this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> e, IHtmlContent editor)
        => html.ForShow(e, editor,
            html.ValidationMessageFor(e, "", new { @class = "text-danger" }));
}
