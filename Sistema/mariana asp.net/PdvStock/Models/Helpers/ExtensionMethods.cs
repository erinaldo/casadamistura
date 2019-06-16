using PdvStock.Utils;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc.Html
{
    public static class Editores
    {
        public static MvcHtmlString ChosenFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, MultiSelectList Listagem, object htmlAttributes = null, Boolean GerarScript = true)
        {
            string propertyName = ExpressionHelper.GetExpressionText(expression);
            return Chosen(helper, propertyName.ToString().Trim(), Listagem, htmlAttributes, GerarScript);
        }
        public static MvcHtmlString ChosenAjaxFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, MultiSelectList Selecionados, String Url, String TermName, String ValueName, String LabelName, int MinLength, object htmlAttributes = null)
        {
            string propertyName = ExpressionHelper.GetExpressionText(expression);
            var Nome = propertyName.ToString().Trim();
            return ChosenAjax(helper, Selecionados, Nome, Url, TermName, ValueName, LabelName, MinLength, htmlAttributes);
        }

        public static MvcHtmlString ChosenAjax<TModel>(this HtmlHelper<TModel> helper, MultiSelectList Selecionados, String Nome, String Url, String TermName, String ValueName, String LabelName, int MinLength, object htmlAttributes = null)
        {
            var chosenObj = Chosen(helper, Nome.Trim(), Selecionados, htmlAttributes).ToString();
            var script = ""
                + "$(document).on('keyup', $(\"#" + Nome.Trim() + "_chosen input\"), function (e) {"
                    + "var texto = $(\"#" + Nome.Trim() + "_chosen input\").val();"
                    + "var min_terms = " + MinLength + ";"
                    + "var canRequestAgain = true;"
                    + "if (texto.length >= min_terms && canRequestAgain) {"
                        + "canRequestAgain = false;"
                        + "$.ajax({"
                            + "url:'" + Url + "',"
                            + "data: {"
                                + "'" + TermName + "' : texto , "
                            + "},"
                            + "success: function (data) {"
                                + "$(\"#" + Nome.Trim() + " option:not(:selected)\").remove();"
                                + "$.each(data, function (i, item) {"
                                    + "if($(\"#" + Nome.Trim() + " option[value='\" + item.Id + \"']\").length == 0){"
                                      + "$(\"#" + Nome.Trim() + "\").prepend(\"<option value='\" + item." + ValueName + " + \"'>\" + item." + LabelName + " + \"</option>\");"
                                    + "}"
                                    + "$(\"#" + Nome.Trim() + "\").trigger('chosen:updated');"
                                    + "$(\"#" + Nome.Trim() + "_chosen input\").val(texto);"
                                    + "$(\"#" + Nome.Trim() + "_chosen input\").attr('style', 'width:auto');"
                               + " }); canRequestAgain = true;"
                          + "  }"
                       + " });"
                    + "}"
               + " });</script>";
            chosenObj = chosenObj.Replace("</script>", script);
            return new MvcHtmlString(chosenObj);
        }
        public static MvcHtmlString Chosen<TModel>(this HtmlHelper<TModel> helper, String Nome, MultiSelectList Listagem, object htmlAttributes = null, Boolean GerarScript = true)
        {
            TagBuilder select = new TagBuilder("select");
            select.Attributes.Add("name", Nome);
            select.Attributes.Add("id", Nome);
            String options = "";
            if (Listagem != null)
            {
                foreach (var item in Listagem)
                {
                    TagBuilder option = new TagBuilder("option");
                    if (item.Selected) option.Attributes.Add("selected", "selected");
                    if (item.Disabled) option.Attributes.Add("disabled", "disabled");
                    option.Attributes.Add("value", item.Value);
                    option.InnerHtml = item.Text;
                    options += option.ToString();
                }
            }
            select.InnerHtml = options;
            List<KeyValuePair<string, object>> chosenOptions = new List<KeyValuePair<string, object>>();
            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                if (attributes.Where(c => c.Key.ToLower() == "class").Any())
                {
                    attributes["class"] = ("" + attributes["class"]).Replace("chosen", "") + " chosen";
                }
                else
                {
                    attributes.Add("class", "chosen");
                }
                chosenOptions = attributes.Where(c => c.Key.ToLower().Contains("chosen-")).ToList();
                select.MergeAttributes(attributes);
            }
            String script = "";
            String choptions = "";
            if (chosenOptions.Count == 0)
            {
                chosenOptions.Add(new KeyValuePair<string, object>("no_results_text", Resource.ChosenNoResults));
                chosenOptions.Add(new KeyValuePair<string, object>("placeholder_text_multiple", Resource.ChosenTextMultiple));
                chosenOptions.Add(new KeyValuePair<string, object>("placeholder_text_single", Resource.ChosenSelectOne));
                chosenOptions.Add(new KeyValuePair<string, object>("search_contains", "true"));
            }
            choptions += "{";
            foreach (var opt in chosenOptions)
            {
                var value = "" + opt.Value;
                var key = "" + opt.Key;
                key = key.Replace("chosen-", "").Trim();
                key = key.Replace("-", "_").Trim();
                value = value.Replace("'", "''").Trim();
                choptions += key + ":'" + value + "' ,";
            }
            choptions += "}";
            if (GerarScript)
            {
                var id = Guid.NewGuid().ToString();
                script = "<script id='" + id + "'>"
                            + "$(document).ready(function(){$('#" + id + "').appendTo(document.body);"
                                + "$('#" + select.Attributes.Where(k => k.Key == "id").FirstOrDefault().Value + "').chosen(" + choptions + ");"
                            + "});"
                    + "</script>";
            }
            return new MvcHtmlString(select.ToString() + script);
        }

        public static MvcHtmlString AutoComplete<TModel>(this HtmlHelper<TModel> helper, String ValorSelecionado, String Nome, String Url, String TermName, String ValueName, String LabelName, int MinLength, object htmlAttributes = null, Boolean GerarScript = true)
        {
            String html = "";
            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("name", Nome);
            input.Attributes.Add("id", Nome);
            input.Attributes.Add("value", ValorSelecionado);
            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                input.MergeAttributes(attributes);
            }
            html += input.ToString();
            if (GerarScript)
            {
                //0 = ValorSelecionado,1 = Nome , 2 = url , 3 = TermName , 4 = ValueName , 5 = LabelName , 6 = MinLength
                html += String.Format(@"
               <script>
                  $(document).ready(function(){
                    $('#{1}').val('{0}');
                    $('#{1}').autocomplete({
                        source: function (request, response) {
                            $.ajax({
                               url: '{2}',
                               dataType: 'json',
                                contentType: 'application/json, charset=utf-8',
                                data: {
                                    '{3}': $('#{1}').val()
                                },
                                success: function (data) {
                                    response($.map(data, function (item) {
                                        return {
                                            id: item.{4},
                                            label: item.{5}
                                        };
                                    }));
                                },
                                error: function (xhr, status, error) {
                                    console.log(xhr);
                                    console.log(status);
                                    console.log(error);
                                }
                            });
                        },
                        minLength: {6},
                    });
                });
            </script>"
                    , ValorSelecionado, Nome, Url, TermName, ValueName, LabelName, MinLength.ToString());
            }
            return new MvcHtmlString(html);
        }
    
    }
}