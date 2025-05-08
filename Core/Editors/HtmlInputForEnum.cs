using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc.Core.Editors;

public static class HtmlInputForEnum {
    public static IHtmlContent InputForEnum<TModel, TResult>(
        this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> e) =>
        html.SelectFor(e, selectList<TResult>());
    private static SelectList selectList<TEnum>() {
        var t = typeof(TEnum);
        var x = Nullable.GetUnderlyingType(t);
        if (x != null) t = x;
        return new(Enum.GetNames(t));
    }
}