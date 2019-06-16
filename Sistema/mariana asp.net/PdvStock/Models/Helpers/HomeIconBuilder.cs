using PdvStock.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PdvStock
{
    public class HomeBuilder
    {
        private const int LimitPerRow = 4;
        private List<HomeItem> HomeItems = new List<HomeItem>();

        public static HomeItem Item() { 
            return new HomeItem();
        }
       
        public static HomeBuilder New() {
            return new HomeBuilder();
        }
       
        public HomeBuilder Add(HomeItem Item)
        {       
            HomeItems.Add(Item);
            return this;
        }
       
        public MvcHtmlString Render(){
            String html = "";
            int From = 0;
            int linhas = (int)Math.Ceiling((double)HomeItems.Count / 4);
            for (int i = linhas; i > 0; i--)
            {
                var items = HomeItems
                            .OrderBy(e => !e.Order.HasValue)
                            .Where(e=>e.Visible)
                            .Skip(From)
                            .Take(LimitPerRow)
                            .ToList();
                html += "<div class=\"row dashboard\">";
                foreach (var item in items)
                {
                    String div = ""
                    + "<div class='col-xs-12 col-sm-3 col-md-3 col-lg-3'>"
                    + "   <a href='" + item.Url + "' "+RenderAttrs(item.HtmlAttrs)+"'>"
                    + "	    <div class='info'>"
                    ;
                    if (System.IO.File.Exists(ServerUtil.GetBasePath() + item.Icon))
                    {
                        div += "           <p><img class='box-icon' style='width:80px;height:80px;' src='" + item.Icon + "'/></p>";
                    }
                    else if (item.Icon != "no-icon")
                    {

                        div += "           <p><span class='box-icon fa fa-4x " + item.Icon + "'></span></p>";
                    }
                    div += "           <p align='center' style='font-size:14px;font-weight:bold;color:#000'>" + item.Title + "</p>"
                    + "           <p>" + item.Description + "</p>"
                    + "      </div>"
                    + "    </a>"
                    + "</div>";

                    html += div;
                }
                From += 4;
                html += "</div>";
            }
            return new MvcHtmlString(html);
        }

        private string RenderAttrs(IDictionary<string, string> dictionary)
        {
            if (dictionary == null) return "";
            String attrs = "";
            if (dictionary.Where(c => c.Key.Trim() == "class").Any())
            {
                dictionary["class"] = "box " + dictionary["class"];
            }
            else { 
                dictionary.Add("class","box");
            }
            foreach(var attr in dictionary){

                attrs += " " + attr.Key + "=\"" + attr.Value.Replace("\"", "&quot;") +"\" ";
            }
            return attrs;
        }
    }
    public class HomeItem
    {
        public String Title { get; set; }
        public String Url { get; set; }
        public String Icon { get; set; }
        public String Description { get; set; }
        public Boolean Visible { get; set; }
        public int? Order { get; set; }
        public IDictionary<string, string> HtmlAttrs { get; set; }

        public HomeItem() {
            Order =  null;
            Visible = true;
            HtmlAttrs = new Dictionary<string, string>();
        }
        public HomeItem SetTitle(String Title)
        {
            this.Title = Title;
            return this;
        }
        public HomeItem SetUrl(String Url)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            this.Url = urlHelper.Content(Url);
            return this;
        }
        public HomeItem SetUrl(String actionName, String controllerName)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            Url = urlHelper.Action(actionName, controllerName);
            return this;
        }
        public HomeItem SetUrl(String actionName, String controllerName, Object routeValues)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            Url = urlHelper.Action(actionName, controllerName,routeValues);
            return this;
        }
        public HomeItem SetUrl(String actionName, String controllerName, Object routeValues,String protocol)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            Url = urlHelper.Action(actionName, controllerName, routeValues,protocol);
            return this;
        }
      


        //public HomeItem SetUrl(String actionName, String controllerName)
        //{
        //    //Url = System.Web.Mvc.UrlHelper.GenerateUrl(actionName, controllerName);
        //    return this;
        //}
        public HomeItem SetIcon(String Icon)
        {
            this.Icon = Icon;
            return this;
        }
        public HomeItem SetDescription(String Description)
        {
            this.Description = Description;
            return this;
        }
        public HomeItem SetOrder(int Order)
        {
            this.Order = Order;
            return this;
        }
        public HomeItem SetVisible(bool Visible)
        {
            this.Visible = Visible;
            return this;
        }
        
        public HomeItem AddHtmlAttr(string key, string value)
        {
            HtmlAttrs.Add(key, value);
            return this;
        }

        public HomeItem EnablePopOverHelper(Boolean HtmlContent = false)
        {
            if (HtmlAttrs.Where(c => c.Key == "data-toggle").Any())
                HtmlAttrs["data-toggle"] = "popover";
            else
                HtmlAttrs.Add("data-toggle", "popover");

            if (HtmlAttrs.Where(c => c.Key == "data-html").Any())
                HtmlAttrs["data-html"] = HtmlContent.ToString().ToLower();
            else
                HtmlAttrs.Add("data-html", HtmlContent.ToString().ToLower());

            SetHelperPlacement("auto");
            SetHelperTrigger("hover");

            return this;
        }

        public HomeItem EnableTooltipHelper(Boolean HtmlContent = false)
        {
            if (HtmlAttrs.Where(c => c.Key == "data-toggle").Any())
                HtmlAttrs["data-toggle"] = "tooltip";
            else
                HtmlAttrs.Add("data-toggle", "tooltip");

            if (HtmlAttrs.Where(c => c.Key == "data-html").Any())
                HtmlAttrs["data-html"] = HtmlContent.ToString().ToLower();
            else
                HtmlAttrs.Add("data-html", HtmlContent.ToString().ToLower());


            SetHelperPlacement("auto");
            SetHelperTrigger("hover");

            return this;
        }
        
        public HomeItem SetHelperContent(string content)
        {
            if (HtmlAttrs.Where(c => c.Key == "data-content").Any())
                HtmlAttrs["data-content"] = content;
            else
                HtmlAttrs.Add("data-content", content);
            return this;
        }
        
        ///<summary>
        ///Appends the popover to a specific element
        ///</summary>
        public HomeItem SetHelperContainer(string container)
        {
            if (HtmlAttrs.Where(c => c.Key == "data-container").Any())
                HtmlAttrs["data-container"] = container;
            else
                HtmlAttrs.Add("data-container", container);

            return this;
        }

        public HomeItem SetHelperTitle(string title)
        {

            if (HtmlAttrs.Where(c => c.Key == "title").Any())
                HtmlAttrs["title"] = title;
            else
                HtmlAttrs.Add("title", title);

            return this;
        }

        public HomeItem SetHelperTrigger(string trigger)
        {

            if (HtmlAttrs.Where(c => c.Key == "data-trigger").Any())
                HtmlAttrs["data-trigger"] = trigger;
            else
                HtmlAttrs.Add("data-trigger", trigger);

            return this;
        }

        public HomeItem SetHelperPlacement(string trigger)
        {

            if (HtmlAttrs.Where(c => c.Key == "data-placement").Any())
                HtmlAttrs["data-placement"] = trigger;
            else
                HtmlAttrs.Add("data-placement", trigger);

            return this;
        }
    }
}