using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PdvStock.Utils
{
    public class StringUtil
    {
        public static String FraseCapitalize(String frase)
        {
            if (frase != null)
            {
                frase = frase.Trim();
                if (frase.Length < 1) return frase;
                if (frase.LastIndexOf(' ') == -1) return frase;
                string[] partes = frase.Split(' ');
                frase = "";
                for (int i = 0; i < partes.Count(); i++)
                {
                    partes[i] = StringUtil.PrimeiraLetraUC(partes[i]);
                }
                return String.Join(" ", partes);
            }
            return "";
        }
        //Regex.Replace(s, @"(^\w)|(\s\w)", m => m.Value.ToUpper());

        public static String PrimeiraLetraUC(String p)
        {
            if (p != null)
            {
                p = p.Trim();
                if (p != null)
                {
                    if (p.Length > 0)
                    {
                        string pt = p.Substring(0, 1);
                        pt = pt.ToUpper();
                        p = StringUtil.SubstituirPrimeiraOccorrencia(p, p.Substring(0, 1), pt);
                    }
                }
                return p;
            } return "";
        }

        public static String AjustarLogin(String usuario)
        {
            if (usuario != null)
            {
                if (usuario.Contains("@"))
                {
                    usuario = usuario.Substring(0, usuario.IndexOf("@"));
                }
                return usuario.ToLower().Trim();
            } return "";
        }

        public static string SubstituirPrimeiraOccorrencia(string texto, string buscarPor, string substituirPor)
        {
            int pos = texto.IndexOf(buscarPor);
            if (pos < 0)
            {
                return texto;
            }
            return texto.Substring(0, pos) + substituirPor + texto.Substring(pos + buscarPor.Length);
        }

        /// <summary>
        /// Remove caracteres não numéricos
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveNaoNumericos(string text)
        {
            if (text != null)
            {
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
                string ret = reg.Replace(text, string.Empty);
                return ret;
            }
            return "";
        }

        /// <summary>
        /// Valida se um cpf é válido
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool ValidaCPF(string cpf)
        {
            if (cpf == null) return false;
            //Remove formatação do número, ex: "123.456.789-01" vira: "12345678901"
            cpf = StringUtil.RemoveNaoNumericos(cpf);

            if (cpf.Length > 11)
                return false;

            while (cpf.Length != 11)
                cpf = '0' + cpf;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                    return false;

            return true;
        }
        public static String formataCPF(String cpf)
        {
            if (cpf != null)
            {
                if (cpf.Length == 11)
                {
                    return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
                }
                return cpf;
            }
            return "";
        }
        public static String formataCelular(String celular)
        {
            if (celular != null)
            {
                if (celular.Length == 11)
                {
                    return Convert.ToUInt64(celular).ToString(@"(00)00000-0000");
                }
                else if (celular.Length == 10)
                {
                    return Convert.ToUInt64(celular).ToString(@"(00)0000-0000");
                }

                return celular;
            }
            return "";
        }

        private static Random random = new Random((int)DateTime.Now.Ticks);
     
        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public static String NullParaEmpty(String valor)
        {
            if (valor == null) return "";
            if (valor == "NULL") return "";
            return valor.Trim();
        }

       public static bool hasEmpty(params string[] strings)
        {
            foreach (String s in strings) 
            { 
                String st = s ?? "";
                st = st.Trim();
                if (String.IsNullOrEmpty(st))
                    return true;
            }
            return false;
        }
        public static bool hasZeroEmpty(params string[] strings)
        {
            foreach (String s in strings)
            {
                String st = s ?? "";
                st = st.Trim();
                if(st == "0")
                    st = "";
                if (String.IsNullOrEmpty(st))
                    return true;
            }
            return false;
        }
    }
}