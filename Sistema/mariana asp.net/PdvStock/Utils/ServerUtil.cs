using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;


namespace PdvStock.Utils
{
    public class ServerUtil
    {
        public static string GetUserIP()
        {
            if (HttpContext.Current != null)
            {
                var request = HttpContext.Current.Request;
                string ipList = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (!string.IsNullOrEmpty(ipList))
                {
                    return ipList.Split(',')[0];
                }
                return request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                return "#L:26# ERRO DE IP ";
            }

        }
        public static string GetUserBrowser()
        {
            if (HttpContext.Current != null)
            {
                var request = HttpContext.Current.Request;
                HttpBrowserCapabilities browserObj = request.Browser;
                return browserObj.Browser + " " + browserObj.Version;
            }
            return "Other";
        }
        public static HttpBrowserCapabilities GetUserBrowserName()
        {
            if (HttpContext.Current != null)
            {
                var request = HttpContext.Current.Request;
                HttpBrowserCapabilities browserObj = request.Browser;
                return browserObj;
            }
            return null;
        }
        public static string GetUserBrowserObj()
        {
            if (HttpContext.Current != null)
            {
                var request = HttpContext.Current.Request;
                HttpBrowserCapabilities browserObj = request.Browser;
                return browserObj.Browser;
            }
            return "Other";
        }
        public static double GetUserBrowserVersion()
        {
            if (HttpContext.Current != null)
            {
                var request = HttpContext.Current.Request;
                HttpBrowserCapabilities browserObj = request.Browser;
                return Convert.ToDouble(browserObj.Version);
            }
            return 0.0;
        }
        public static bool BrowserIsInternetExplorer()
        {
            if (HttpContext.Current != null)
            {
                var request = HttpContext.Current.Request;
                HttpBrowserCapabilities browserObj = request.Browser;
                if (browserObj.Browser.Contains("InternetExplorer")) return true;
                if (browserObj.Browser.Contains("Internet Explorer")) return true;
                if (browserObj.Browser.Contains("IExplorer")) return true;
                if (browserObj.Browser.Contains("MSIE")) return true;

            }
            return false;
        }
        public static string GetUrlOrigem()
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
            }
            else
            {
                return "# Sem Origem #";
            }
        }
        ///
        /// Checks the file exists or not.
        ///
        /// The URL of the remote file.
        /// True : If the file exits, False if file not exists
        public static bool RemoteFileExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                //Returns TRUE if the Status code == 200
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }

        public static string GetHostName()
        {
            return System.Web.HttpContext.Current.Request.Url.Host + ":" + System.Web.HttpContext.Current.Request.Url.Port;
        }
        public static string GetBaseUrl()
        {
            return System.Web.HttpContext.Current.Request.Url.Scheme + "://" + System.Web.HttpContext.Current.Request.Url.Authority + System.Web.HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";
        }

        public static bool LocalFileExists(String path)
        {
            if (path == null) return false;
            if (path == "") return false;
            if (System.IO.File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static String GetBasePath()
        {
            return HttpContext.Current.Server.MapPath("~\\");
        }

        public static String GetPathFor(String Pasta)
        {
            char DirSeparator = System.IO.Path.DirectorySeparatorChar;
            return HttpContext.Current.Server.MapPath("~\\" + Pasta + DirSeparator);
        }

        public static string GetCompileTime()
        {
            var entryAssembly = Assembly.GetExecutingAssembly();
            var fileInfo = new FileInfo(entryAssembly.Location);
            var buildDate = fileInfo.LastWriteTime;
            return buildDate.ToString();
        }

        public static string GetVersion()
        {
            return "V" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}