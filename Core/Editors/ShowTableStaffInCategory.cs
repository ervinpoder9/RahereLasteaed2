using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Core.Editors;

public static class ShowTableStaffInCategory
{
    #region 
    private static bool isRelated;
    public static IHtmlContent RelatedTableStaffInCategory<TModel>(
        this IHtmlHelper<IEnumerable<TModel>> h, IEnumerable<TModel> list,
        params string[] propsToShow)
    {
        isRelated = true;
        string[] orderedProps = new[]
        {
            "Position", "Name", "Surname", "IDNumber",
            "Address", "Mobile", "Email", "Education", "AdditionalInfo"
        };
        var r = h.ShowTableStaffInCat(list, false, orderedProps);
        isRelated = false;
        return r;
    }    
    public static IHtmlContent ShowTableStaffInCat<TModel>(
        this IHtmlHelper<IEnumerable<TModel>> h, IEnumerable<TModel> list,
        bool hasSelect = false, params string[] propsToShow)
    {
        var props = getProperties<TModel>();
        if (propsToShow.Length > 0)
        {
            var dict = props.ToDictionary(p => p.Name);
            props = propsToShow
                .Where(dict.ContainsKey)
                .Select(name => dict[name])
                .ToArray();
        }
        var tbl = createTable();
        tbl.InnerHtml.AppendHtml(h.createHeader(props));
        tbl.InnerHtml.AppendHtml(h.createBody(props, list, hasSelect));
        return tbl;
    }    
    private static PropertyInfo[] getProperties<TModel>()
        => typeof(TModel)?.GetProperties().Where(p => p.Name != "Id").ToArray() ?? [];
    private static TagBuilder createTable()
    {
        var t = tblTag;
        t.AddCssClass("table");
        t.AddCssClass("nice-table");
        return t;
    }
    private static TagBuilder tblTag => new("table");
    private static IHtmlContent createHeader<TModel>(
        this IHtmlHelper<IEnumerable<TModel>> h, PropertyInfo[] properties)
    {
        var header = tblHdrTag;
        var row = tblRowTag;
        if (isRelated)
            row.AddCssClass("table-secondary");
        foreach (var p in properties)
        {
            var col = tblColTag;
            var name = displayNameFor(p);
            name = h.updateDisplayName(name, p.Name);
            var sortOrder = h.updateSortOrder(p.Name);
            var link = $"<a href=\"?pageIdx=0&orderBy={sortOrder}&filter={h.ViewBag.Filter}\">{name}</a>";
            col.InnerHtml.AppendHtml(isRelated ? name : link);
            row.InnerHtml.AppendHtml(col);
        }
        if (!isRelated)
            row.InnerHtml.AppendHtml(tblColTag);
        header.InnerHtml.AppendHtml(row);
        return header;
    }
    private static string updateDisplayName<TModel>(
        this IHtmlHelper<IEnumerable<TModel>> h, string name, string propName)
    {
        var sortOrder = h.ViewBag.OrderBy as string;
        if (sortOrder == propName)
            name += " ▲";
        else if (sortOrder == propName + "_desc")
            name += " ▼";
        return name;
    }
    private static string updateSortOrder<TModel>(
        this IHtmlHelper<IEnumerable<TModel>> h, string propName)
    {
        var sortOrder = h.ViewBag.OrderBy as string;
        if (sortOrder == propName)
            return propName += "_desc";
        else
            return propName;
    }
    private static TagBuilder tblHdrTag => new("thead");
    private static TagBuilder tblRowTag => new("tr");
    private static TagBuilder tblColTag => new("th");
    private static string displayNameFor(PropertyInfo p)
        => p.GetCustomAttribute<DisplayAttribute>()?.Name ?? p.Name;
    private static IHtmlContent createBody<TModel>(
        this IHtmlHelper<IEnumerable<TModel>> h,
        PropertyInfo[] properties, IEnumerable<TModel> list, bool hasSelect)
    {
        var tblBody = tblBodyTag;
        foreach (var item in list)
        {
            var id = getId<TModel>(item);
            var row = tblRowTag;
            if (!isRelated && id == h.ViewBag.SelectedId)
                row.AddCssClass("table-success");
            foreach (var p in properties)
            {
                var data = tblDataTag;
                var value = getValue(p, item);
                data.InnerHtml.AppendHtml(value);
                row.InnerHtml.AppendHtml(data);
            }
            if (!isRelated)
                h.addHrefs(row, item, hasSelect);
            tblBody.InnerHtml.AppendHtml(row);
        }
        return tblBody;
    }
    private static TagBuilder tblBodyTag => new("tbody");
    private static TagBuilder tblDataTag => new("td");
    private static IHtmlContent getValue<TModel>(PropertyInfo? p, TModel? item)
    {
        var v = p?.GetValue(item);
        var dt = v as DateTime?;
        if (dt != null)
            return new HtmlString(dt?.ToShortDateString() ?? "");
        return new HtmlString(v?.ToString() ?? "");
    }
    private static int getId<TModel>(object? item)
        => typeof(TModel).GetProperty("Id")?.GetValue(item) as int? ?? 0;

    private static void addHrefs<TModel>(
        this IHtmlHelper<IEnumerable<TModel>> h, TagBuilder row, TModel item
        , bool hasSelect)
    {
        var id = getId<TModel>(item);
        var td = tblDataTag;
        var sel = h.hrefSel(id);        
        if (hasSelect)
        {
            td.InnerHtml.AppendHtml(sel);
            td.InnerHtml.Append(" ");
        }
        
        row.InnerHtml.AppendHtml(td);
    }
    private static IHtmlContent hrefSel<TModel>(this IHtmlHelper<IEnumerable<TModel>> h, int i)
        => h.ActionLink("Select", "Index", new
        {
            selectedId = i,
            pageIdx = h.ViewBag.PageIdx,
            orderBy = h.ViewBag.OrderBy,
            filter = h.ViewBag.Filter
        });

    #endregion    
}