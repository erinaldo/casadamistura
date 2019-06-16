using PdvStock;
using PdvStock.Models;
using PdvStock.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PdvStock.Controllers
{
    public class LoginController : BaseController
    {
        /**
        * Efetua o login
        */
        public ActionResult Index(string returnUrl, string SimularUsuario)
        { 
            //Verifica se usuário já esta logado redireciona a pagina q ele ja tinha salvo
            if (DadosUsuario.UsuarioLogado())
            {
                if (returnUrl!=null&&returnUrl.Trim().Equals(""))
                {
                    returnUrl = "./";
                }
                return Redirect(returnUrl);
            }
            if (Debug)
            {
                return DevelopmentLogin(returnUrl);
            }
            //Verifica se ele está logando por um url especifico
            ViewBag.returnUrl = returnUrl;
            UsuarioLogin model = new UsuarioLogin();
            //Verifica se ele tem Cookies para login rapido
            if (CookieUtil.TemLoginCookie())
            {
                string uCookie = CookieUtil.GetLoginCookieU();
                string sCookie = CookieUtil.GetLoginCookieS();
                model.Usuario = SecurityUtil.Base64Decode(uCookie);
                model.Senha = SecurityUtil.Base64Decode(sCookie);
                return this.CookieLogin(model, returnUrl, SimularUsuario);
            }
            ViewBag.SimularUsuario = SimularUsuario;
            return View();
        }

        /**
        * Efetua o login [POST] 
        */
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(UsuarioLogin model, string returnUrl, string SimularUsuario)
        {
            //Pega o Url de Retorno caso o login venha de uma url especifica
            ViewBag.returnUrl = returnUrl;
            //Se usuario vazio retorna
            if (model.Usuario.Length > 0 || model.Senha.Length > 0)
            {
                //Faz Atenticação no webservice e pega a resposta (DadosDoUsuario)
                var resultado = this.ControleDeAutenticacao(model.Usuario, model.Senha, SimularUsuario);
                if (resultado.Erro)
                {
                    //Erros que podem ocorreu pega a mensagem
                    ViewBag.Erros = resultado.ErroMsg;
                }
                else
                {
                    try
                    {
                        //Set nas Sessões dos DadosDoUsuario
                        DadosUsuario.SetResultado(resultado);
                        if (model.RememberMe)
                        {
                            CookieUtil.SetRememberMe(true);
                            CookieUtil.SetTokenU(SecurityUtil.Base64Encode(model.Usuario));
                            CookieUtil.SetTokenS(SecurityUtil.Base64Encode(model.Senha));
                        }
                        if (returnUrl.Trim().Equals(""))
                        {
                            returnUrl = "./";
                        }
                        return Redirect(returnUrl);
                    }
                    catch (Exception e)
                    {
                        ViewBag.Erros = "Ocorreu um erro inesperado , tente novamente em alguns minutos. Caso erro persista contate o suporte 9335";
                    }
                }
            }
            ViewBag.SimularUsuario = SimularUsuario;
            return View("index");
        }
        /**
        *  Loga atraves de cookie
        */
        public ActionResult CookieLogin(UsuarioLogin model, string returnUrl, string SimularUsuario)
        {
            //Pega o Url de Retorno caso o login venha de uma url especifica
            ViewBag.returnUrl = returnUrl;
            //Se usuario vazio retorna
            if (model.Usuario.Length > 0 || model.Senha.Length > 0)
            {
                //Faz Atenticação no webservice e pega a resposta (DadosDoUsuario)
                var resultado = this.ControleDeAutenticacao(model.Usuario, model.Senha, SimularUsuario);
                if (resultado.Erro)
                {
                    ViewBag.Erros = resultado.ErroMsg;
                }
                else
                {
                    try
                    {
                        DadosUsuario.SetResultado(resultado);
                        if (returnUrl.Trim().Equals(""))
                        {
                            returnUrl = "./";
                        }
                        return Redirect(returnUrl);
                    }
                    catch (Exception e)
                    {
                        ViewBag.Erros = "Ocorreu um erro inesperado , tente novamente em alguns minutos. Caso erro persista contate o suporte 9335";
                    }
                }
            }
            return View("index");
        }
       
        /**
         * Faz a autenticacao no webservice
         **/
        public DadosDoUsuario ControleDeAutenticacao(String Login, String Senha, string SimularUsuario)
        {
            //Inicia o Servico
            var servico = new ServicoAcesso();
            servico.UserAgent = ServerUtil.GetUserBrowser();
            DadosDoUsuario resultado = null;

            //Para debugar
            if (Debug)
            {
                resultado = AdHelper.GetDebugAd();
                return resultado;
            }

            //Autentica no webservice
            //garante o parametro para o webservice
            if (SimularUsuario == null) SimularUsuario = "";
            try
            {
                resultado = servico.AutenticarGeral(Login, Senha, IdSistema,  ServerUtil.GetUserBrowser(), ServerUtil.GetUserIP(), ServerUtil.GetUrlOrigem(),SimularUsuario);
            }
            catch (Exception e)
            {
                resultado = new DadosDoUsuario();
                resultado.Erro = true;
                resultado.ErroMsg = "Falha ao se conectar com o servidor de autenticação";
                resultado.ErroCode = 1004;
            }

            return resultado;
        }

        /**
         * Login de debug
         **/
        public ActionResult DevelopmentLogin(String ReturnUrl) {
            //Faz Atenticação no webservice e pega a resposta (DadosDoUsuario)
            var resultado = this.ControleDeAutenticacao("", "", "");
            //Set nas Sessões dos DadosDoUsuario
            DadosUsuario.SetResultado(resultado);
            if (ReturnUrl.Trim().Equals(""))
            {
                ReturnUrl = "./";
            }
            return Redirect(ReturnUrl);
        }


        /*
        * Mata Sessao e cookie
        * */
        public ActionResult Sair()
        {
            Session.Clear();
            CookieUtil.ClearLogin(); 
            return View("index");
        }


    }
}