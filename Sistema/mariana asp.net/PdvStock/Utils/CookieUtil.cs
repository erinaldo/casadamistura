using PdvStock.Controllers;
using PdvStock.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PdvStock.Utils
{
    public static class CookieUtil
    {

        private static readonly String TokenU = "u" + SecurityUtil.Base64Encode(SecurityUtil.Base64Encode("" + BaseController.IdSistema)).Replace("=", "");
        private static readonly String TokenS = "s" + SecurityUtil.Base64Encode(SecurityUtil.Base64Encode("" + BaseController.IdSistema)).Replace("=", "");


        public static void SetRememberMe(bool p)
        {
            if (HttpContext.Current != null)
            {
                var h = HttpContext.Current;
                h.Session["RememberMe"] = p;
                h.Response.Cookies["RememberMe"].Value = "1";
                h.Response.Cookies["RememberMe"].Expires = DateTime.Now.AddHours(1);
            }
        }

        public static bool GetRememberMe()
        {
            if (HttpContext.Current != null)
            {
                var h = HttpContext.Current;
                if (h.Request.Cookies["RememberMe"] == null) return false;
                if (h.Request.Cookies["RememberMe"].Value == "1") return true;
            }
            return false;
        }

        public static void RenovarRemember()
        {
            if (HttpContext.Current != null)
            {
                var h = HttpContext.Current;
                if (CookieUtil.TemLoginCookie())
                {
                    var u = CookieUtil.GetLoginCookieU();
                    var s = CookieUtil.GetLoginCookieS();
                    var rem = ""+Convert.ToInt16(CookieUtil.GetRememberMe());

                    var d = DateTime.Now.AddHours(1);
                    CookieUtil.SetCookie("RememberMe", rem, d);
                    CookieUtil.SetCookie(TokenU, u, d);
                    CookieUtil.SetCookie(TokenS, s, d);
                }
            }
        }

        public static bool TemLoginCookie()
        {
            if (HttpContext.Current != null)
            {
                var h = HttpContext.Current;
                var uR = CookieUtil.GetLoginCookieU();
                var uS = CookieUtil.GetLoginCookieS();
                if (!String.IsNullOrEmpty(uR) && !String.IsNullOrEmpty(uS))
                {
                    return true;   
                }
            }
            return false;
        }

        public static void SetTokenU(string u)
        {
            if (HttpContext.Current != null)
            {
                var h = HttpContext.Current;
                h.Response.Cookies[TokenU].Value = u;
                h.Response.Cookies[TokenU].Expires = DateTime.Now.AddHours(1);
            }   
        }

        public static void SetTokenS(string s)
        {
             if (HttpContext.Current != null)
            {
                var h = HttpContext.Current;
                h.Response.Cookies[TokenS].Value = s;
                h.Response.Cookies[TokenS].Expires = DateTime.Now.AddHours(1);
            }
        }

        public static string GetLoginCookieU()
        {
            if (HttpContext.Current != null)
            {
                var h = HttpContext.Current;
                var cookie = h.Request.Cookies[TokenU];
                if (cookie != null)
                {
                    var u = cookie.Value;
                    if (u != null) return u;
                }
            }
            return "";
        }

        public static string GetLoginCookieS()
        {
            if (HttpContext.Current != null)
            {
                var h = HttpContext.Current;
                var cookie = h.Request.Cookies[TokenS];
                if (cookie != null)
                {
                    var s = cookie.Value;
                    if (s != null) return s;
                }
            }
            return "";
        }

        public static void ClearLogin()
        {
            if (HttpContext.Current != null)
            {
                var h = HttpContext.Current;
                h.Response.Cookies[TokenS].Value = null;
                h.Response.Cookies[TokenS].Expires = DateTime.Now.AddMilliseconds(1);
                h.Response.Cookies[TokenU].Value = null;
                h.Response.Cookies[TokenU].Expires = DateTime.Now.AddMilliseconds(1);
                h.Session["RememberMe"] = false;
            }
        }

        public static string GetCookie(String key) {
            if (String.IsNullOrEmpty(key)) return "";
            if (HttpContext.Current != null)
            {
                var h = HttpContext.Current;
                if (h.Request.Cookies[key] != null){
                    return h.Request.Cookies[key].Value;
                }
            }
            return "";
        }
        public static bool RenovarCookie(String key,DateTime duracao) {
            if (String.IsNullOrEmpty(key)) return false;
            if (HttpContext.Current != null)
            {
                var h = HttpContext.Current;
                var value = CookieUtil.GetCookie(key);
                return CookieUtil.SetCookie(key, value, duracao);
            }
            return false;
        }
        public static bool SetCookie(String key, String value, DateTime duracao) {
            if (String.IsNullOrEmpty(key)) return false;
            if (HttpContext.Current != null)
            {
                var h = HttpContext.Current;
                h.Response.Cookies[key].Value = value;
                h.Response.Cookies[key].Expires = duracao;
                return true;
            }
            return false;
        }
    }
}