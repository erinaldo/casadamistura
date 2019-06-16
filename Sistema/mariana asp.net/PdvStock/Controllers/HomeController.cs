using PdvStock.Models;
using PdvStock.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace PdvStock.Controllers
{
    [NoCache]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Configuracoes()
        {
            //DadosUsuario.GetUsuario()
            UsuarioConfiguracao usuarioConfiguracao = new UsuarioConfiguracao(DadosUsuario.GetUsuario());
            return View(usuarioConfiguracao);
        }

        [HttpPost]
        [NoCache]
        public ActionResult Configuracoes(UsuarioConfiguracao model)
        {
            if (ModelState.IsValid)
            {
                model.SaveCookies(DadosUsuario.GetUsuario());
                return RedirectToAction("Configuracoes");
            }
            return View(model);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /* Componentes */
        public ActionResult Componentes()
        {
            return View();
        }

        public ActionResult DatePicker()
        {
            return View();
        }

        public ActionResult GridMVC()
        {
            return View();
        }
        public ActionResult Json()
        {
            return View();
        }

        /**
        * Erro de não autorizado
        */
        public ActionResult Error1002()
        {
            return View();
        }

        /**
        * Erro de não encontrado
        */
        public ActionResult Error404()
        {
            
            return View();
        }

        /**
         * Erro de requisão inválida
         */
        public ActionResult Error400()
        {
            return View();
        }

        /**
        * Erro de código
        */
        public ActionResult Error500()
        {
            return View();
        }


        /**
         * Dados do Usuário
         */

        public ActionResult MeusDados()
        {
            return View();
        }

        [NoRequireLogin]
        public JsonResult ChangeCulture(string culture)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            }
            catch (Exception e) {
                culture = "pt-BR";
            }
            return Json(new {resultado = CookieUtil.SetCookie("CurrentCulture",culture,DateTime.Now.AddYears(1))});
            
        }
        //public JsonResult FotoPerfil()
        //{
        //    return Json(new { src = DadosUsuario.UrlFoto() },JsonRequestBehavior.AllowGet);
        //}

    }
}