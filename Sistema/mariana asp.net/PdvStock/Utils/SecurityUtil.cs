using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PdvStock.Utils
{
    public class SecurityUtil
    {
        public static string Base64Encode(string texto)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(texto);
            return System.Convert.ToBase64String(bytes);
        }
        public static string Base64Decode(string base64texto)
        {
            var bytes = System.Convert.FromBase64String(base64texto);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
        public static String Base64Encode(Byte[] bytes)
        {
            if (bytes != null && bytes.Length > 0)
            {
                return System.Convert.ToBase64String(bytes);
            }
            return "";
        }
        public static Byte[] Base64DecodeToByte(String base64Bytes)
        {
            if (base64Bytes != null && base64Bytes.Length > 0)
            {
                return System.Convert.FromBase64String(base64Bytes);
            }
            return null;
        }
    }
}