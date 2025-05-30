using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
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

        var values = Enum.GetValues(t).Cast<Enum>()
           .Select(e =>
           {
               var field = e.GetType().GetField(e.ToString());
               var descAttr = field?.GetCustomAttribute<DescriptionAttribute>();
               var text = descAttr?.Description ?? e.ToString();

               return new SelectListItem
               {
                   Value = Convert.ToInt32(e).ToString(),
                   Text = text
               };
           }).ToList();

        return new SelectList(values, "Value", "Text");
    }
}