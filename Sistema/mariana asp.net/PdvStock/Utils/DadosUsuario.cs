using PdvStock.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.DirectoryServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace PdvStock.Utils
{
    public class DadosUsuario
    {

        public static Boolean TemPermissao(String modulo, String acao)
        {
            modulo = modulo.ToLower();
            acao = acao.ToLower();

            if (DadosUsuario.GestorDesteSistema()) return true;
            if (DadosUsuario.LogaTudo()) return true;
            if (DadosUsuario.ModulosDefault(modulo)) return true;
            if (DadosUsuario.GetDadosUsuario() != null)
            {
                var dados = DadosUsuario.GetDadosUsuario();

                if (dados.PerfisUsuario != null)
                {
                    foreach (var p in dados.PerfisUsuario)
                    {
                        var lb = p.Liberacoes.Where(l => l.Url.ToLower().Equals(modulo)).FirstOrDefault();
                        if (lb != null)
                        {
                            var acoes = lb.Acoes.Where(a => a.Url.ToLower().Equals(acao)).FirstOrDefault();
                            if (acoes != null)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public static Boolean TemPermissao(String modulo)
        {
            modulo = modulo.ToLower();
            if (DadosUsuario.GestorDesteSistema()) return true;
            if (DadosUsuario.LogaTudo()) return true;
            if (DadosUsuario.ModulosDefault(modulo)) return true;
            if (DadosUsuario.GetDadosUsuario() != null)
            {
                var dados = DadosUsuario.GetDadosUsuario();

                if (dados.PerfisUsuario != null)
                {
                    foreach (var p in dados.PerfisUsuario)
                    {
                        var lb = p.Liberacoes.Where(l => l.Url.ToLower().Equals(modulo)).FirstOrDefault();
                        if (lb != null)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool GestorDesteSistema()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["GestorDesteSistema"]!=null)
            {
                return (bool)HttpContext.Current.Session["GestorDesteSistema"];
            }
            else
            {
                return false;
            }
        }

        public static void SetResultado(DadosDoUsuario resultado)
        {
            if (HttpContext.Current != null)
            {
                var h = HttpContext.Current;
                h.Session["GestorDesteSistema"] = resultado.GestorDesteSistema;
                h.Session["DadosDoUsuario"] = resultado;
                h.Session["UsuarioLogado"] = true;
            }
        }

        public static DadosDoUsuario GetDadosUsuario()
        {
            if (HttpContext.Current != null)
            {
                var h = HttpContext.Current;
                if (h.Session["DadosDoUsuario"] != null)
                {
                    return (DadosDoUsuario)HttpContext.Current.Session["DadosDoUsuario"];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static String GetUsuario()
        {
            var dados = DadosUsuario.GetDadosUsuario();
            if (dados != null)
            {
                return dados.Usuario;
            }
            else
            {
                return null;
            }
        }

        public static String GetNome()
        {
            var dados = DadosUsuario.GetDadosUsuario();
            if (dados != null)
            {
                return dados.Nome;
            }
            else
            {
                return null;
            }
        }

        public static String GetEmail()
        {
            var dados = DadosUsuario.GetDadosUsuario();
            if (dados != null)
            {
                return dados.Email;
            }
            else
            {
                return null;
            }
        }

        public static String GetTelefone()
        {
            var dados = DadosUsuario.GetDadosUsuario();
            if (dados != null)
            {
                return dados.Telefone;
            }
            else
            {
                return null;
            }
        }

        public static String GetCentroCusto()
        {
            var dados = DadosUsuario.GetDadosUsuario();
            if (dados != null)
            {
                return dados.CentroCusto;
            }
            else
            {
                return null;
            }
        }

        public static String GetDepartamento()
        {
            var dados = DadosUsuario.GetDadosUsuario();
            if (dados != null)
            {
                return dados.Departamento;
            }
            else
            {
                return null;
            }
        }

        public static String GetDisplayNome()
        {
            var dados = DadosUsuario.GetDadosUsuario();
            var configNome = UsuarioConfiguracao.GetInstanceFor(GetUsuario());
            //var configNome = new UsuarioConfiguracao();
            if (dados != null && configNome != null)
            {
                string[] partes = dados.Nome.Trim().Split();

                if (configNome.ExibicaoNome == UsuarioConfiguracao.TipoNome.Completo) return dados.Nome;

                if (configNome.ExibicaoNome == UsuarioConfiguracao.TipoNome.Primeiro)
                {
                    if (partes.Count() > 0)
                    {
                        return partes[0];
                    }
                    else
                    {
                        return dados.Nome;
                    }
                }
                if (configNome.ExibicaoNome == UsuarioConfiguracao.TipoNome.PrimeiroSegundo)
                {
                    if (partes.Count() > 1)
                    {
                        return partes[0] + " " + partes[1];
                    }
                    else
                    {
                        return dados.Nome;
                    }
                }
                if (configNome.ExibicaoNome == UsuarioConfiguracao.TipoNome.PrimeiroUltimo)
                {
                    if (partes.Count() > 1)
                    {
                        return partes[0] + " " + partes[(partes.Count() - 1)];
                    }
                    else
                    {
                        return dados.Nome;
                    }
                }
                if (configNome.ExibicaoNome == UsuarioConfiguracao.TipoNome.Ultimo)
                {
                    if (partes.Count() > 1)
                    {
                        return partes[(partes.Count() - 1)];
                    }
                    else
                    {
                        return dados.Nome;
                    }
                }
                return partes[0];
            }
            else
            {
                return null;
            }
        }

        public static bool UsuarioLogado()
        {
            if (HttpContext.Current != null)
            {
                var h = HttpContext.Current;
                if (h.Session["UsuarioLogado"] == null) { return false; }
                else
                {
                    return (bool)h.Session["UsuarioLogado"];
                }

            }
            else
            {
                return false;
            }

        }

        public static String GetCPF()
        {
            var dados = DadosUsuario.GetDadosUsuario();
            if (dados != null)
            {
             
                 return StringUtil.RemoveNaoNumericos(dados.Cpf);
            }
            else
            {
                return "";
            }
        }
        
        public static String UrlFoto()
        {
            //var url = "http://rhfundacao.butantan.gov.br/Fotos/" + DadosUsuario.GetCPF() + ".jpg";
            if(PdvStock.Controllers.BaseController.Debug)
                return "/Content/images/default.jpg";

            var src = DadosUsuario.PegarFotoAd(DadosUsuario.GetUsuario());
            if (src != "")
            {
                return  src;
            }
            else {
                return "/Content/images/default.jpg";
            }
        }

        public static string PegarFotoAd(String Usuario)
        {
            String srcFoto = "";
            //return;
            if (Usuario == null) return "";
            if (Usuario.Trim().Length == 0) return "";

            Usuario = StringUtil.AjustarLogin(Usuario);
            DirectoryEntry de = new DirectoryEntry("LDAP://172.25.1.7/DC=ibutantan, DC=local");
            de.AuthenticationType = AuthenticationTypes.Secure;
            de.Username = "rh.fotos";
            de.Password = "4r2fs6kT";
            try
            {
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.SearchScope = System.DirectoryServices.SearchScope.Subtree;
                ds.Filter = "(ObjectClass=user)";
                ds.Filter = "(&(objectClass=user)(samaccountname=" + Usuario.Trim() + "))";
                //ds.PropertiesToLoad.Add("thumbnailPhoto");
                ds.PropertiesToLoad.Add("jpegPhoto");
                //ds.PropertiesToLoad.Add("photo");
                //ds.PropertiesToLoad.Add("Picture");
                foreach (SearchResult result in ds.FindAll())
                {
                    DirectoryEntry deResult = result.GetDirectoryEntry();
                    byte[] bytes = null;
                    try
                    {
                        bytes = deResult.Properties["jpegPhoto"][0] as byte[];
                    }
                    catch (Exception e) { }
                    if (bytes != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(bytes);
                        srcFoto = string.Format("data:image/jpeg;base64,{0}", imageBase64Data);
                    }
                }

            }
            catch (Exception ex)
            {
                //TempData["InfoMsg"] = "Foto não encontrada no AD";
            }
            return srcFoto;
        }
        
        public static bool ModulosDefault(String modulo)
        {
            if (modulo.ToLower().Equals("home")) return true;
            if (modulo.ToLower().Equals("login")) return true;

            return false;
        }

        public static bool LogaTudo() {
            var dados = DadosUsuario.GetDadosUsuario();
            if(dados != null){
                return dados.LogaTudo;
            }
            return false;
        }
    }
}