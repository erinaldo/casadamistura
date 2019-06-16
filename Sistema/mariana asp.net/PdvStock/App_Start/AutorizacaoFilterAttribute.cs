using PdvStock.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PdvStock
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            base.OnActionExecuting(filterContext);
            if (!NoLogin(filterContext))
            {
                bool usuarioLogado = (bool)DadosUsuario.UsuarioLogado();

                var cController = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                var aAction = filterContext.ActionDescriptor.ActionName;
                var returnParams = filterContext.ActionParameters;

                var returnUrl = cController + "/" + aAction;
                if (returnParams.Count > 0)
                {
                    returnUrl += "?";
                    foreach (var param in returnParams)
                    {
                        returnUrl += "&" + param.Key + "=" + param.Value;
                    }
                }

                Object resultado = null;
                if (!ErrorRedirect(cController.ToLower(), aAction.ToLower()))
                {
                    if (usuarioLogado)
                    {
                        if (CookieUtil.GetRememberMe())
                        {
                            CookieUtil.RenovarRemember();
                        }
                        Boolean permitido = DadosUsuario.TemPermissao(cController, aAction);

                        if (!permitido)
                        {
                            if (filterContext.HttpContext.Request.IsAjaxRequest())
                            {
                                filterContext.HttpContext.Response.Clear();
                                filterContext.HttpContext.Response.StatusDescription = "Não Autorizado";
                                filterContext.HttpContext.Response.StatusCode = 403;
                                filterContext.HttpContext.Response.AddHeader("WWW-Authenticate", "Basic realm=\"Secure Area\"");
                                filterContext.HttpContext.Response.Write("403, proibido acesso ");
                                filterContext.Result = new EmptyResult();
                                filterContext.HttpContext.Response.End();
                            }
                            else
                            {
                                resultado = new { action = "Error1002", controller = "Home", returnUrl = returnUrl };
                                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(resultado));
                            }
                        }
                    }
                    else
                    {
                        if (!cController.ToLower().Equals("login"))
                        {
                            resultado = new { action = "Index", controller = "Login", returnUrl = returnUrl };
                            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(resultado));
                        }
                    }
                }
            }
        }

        private bool ErrorRedirect(string ctrl, string action)
        {
            if (ctrl.Equals("home"))
            {
                if (action.StartsWith("error")) return true;
            }
            return false;
        }

        private bool NoLogin(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(NoRequireLoginAttribute), false).Any())
            {
                return true;
            }
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(NoRequireLoginAttribute), false).Any())
            {
                return true;
            }
            return false;
        }
    }
}