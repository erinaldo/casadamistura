using PdvStock.br.gov.butatan.servicoemail;
using PdvStock.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using ButantanExtensions;
using System.IO;
using PdvStock.Models;
using System.Web.Routing;
namespace PdvStock.Controllers
{
    /**
     * Classe para funcoes comuns como logs
     * */
    public class BaseController : Controller
    {
        //initilizing culture on controller initialization
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            //var culture = (String)Session["CurrentCulture"];
            var culture = CookieUtil.GetCookie("CurrentCulture");
            if (!String.IsNullOrEmpty(culture) && MultiLinguagem)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(DefaultLang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(DefaultLang);
            }
        }

        //gera o a view em uma string
        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
        /**
         * Se o sistema é multilinguagem
         * e quais utilizando chaves do resource
         * caso false = Portugues , sem selectbox
         * */
        public static bool MultiLinguagem = true;
        protected String DefaultLang = "pt-BR";

        /**
         * Debugar sem login
         * */
        public static readonly bool Debug = false;

        /*
         * Id do Sistema no controle acesso
         */
        public static readonly int IdSistema = 10;

        /*
         * nome do Sistema
         */
        protected String NomeSistema = Resources.Resource.NomeSistema;

        /*
        * Funcoes compartilhadas pelos controllers
        */

     }
}
