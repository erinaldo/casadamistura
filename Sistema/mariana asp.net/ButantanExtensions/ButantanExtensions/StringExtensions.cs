using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ButantanExtensions
{
    //Extension methods must be defined in a static class
    public static class StringExtension
    {
        /// <summary>
        /// Count of Words
        /// </summary>
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },StringSplitOptions.RemoveEmptyEntries).Length;
        }
        /// <summary>
        /// Capitalize Brazilian Name
        /// </summary>
        public static String CapitalizeBrazilianName(this String str)
        {
            string[] excecoes = new string[] { "e", "de", "da", "das", "do", "dos", "di" };
            var palavras = new Queue<string>();
            foreach (var palavra in str.Split(' '))
            {
                if (!string.IsNullOrEmpty(palavra))
                {
                    var emMinusculo = palavra.ToLower();
                    var letras = emMinusculo.ToCharArray();
                    if (!excecoes.Contains(emMinusculo)) letras[0] = char.ToUpper(letras[0]);
                    palavras.Enqueue(new string(letras));
                }
            }
            return string.Join(" ", palavras);
        }

        /// <summary>
        /// Capitalize name as culture
        /// </summary>
        public static String CapitalizeName(this String str) {
            return (String)CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        /// <summary>
        /// Replace first occurrence
        /// </summary>
        public static string ReplaceFirst(this String text, string searchFor, string replacement)
        {
            int pos = text.IndexOf(searchFor);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replacement + text.Substring(pos + searchFor.Length);
        }

        /// <summary>
        /// clear all non numeric chars
        /// </summary>
        public static String ToOnlyNumbers(this String str){
                 System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
                 return reg.Replace(str, string.Empty);
        }

        /// <summary>
        /// Check if is valid cpf
        /// </summary>
        public static bool IsValidCpf(this String cpf)
        {
            //Remove formatação do número, ex: "123.456.789-01" vira: "12345678901"
            cpf = cpf.ToOnlyNumbers();
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


        /// <summary>
        /// String formt to brazilian cpf
        /// </summary>
        public static String ToCPFFormat(this String cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }


        /// <summary>
        /// String formt to brazilian phone number
        /// </summary>
        public static String ToBrazilianPhoneNumber(this String celular)
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

        /// <summary>
        /// Trim spaces and clear duplicates whitespaces
        /// </summary>
        public static string TrimAndReduce(this string str)
        {
            return ConvertWhitespacesToSingleSpaces(str).Trim();
        }
        
        /// <summary>
        /// Clear duplicates whitespaces
        /// </summary>
        public static string ConvertWhitespacesToSingleSpaces(this string value)
        {
            return Regex.Replace(value, @"\s+", " ");
        }

        /// <summary>
        /// Check if is number string
        /// </summary>
        public static bool IsNumber(this string input)
        {
            var match = Regex.Match(input, @"^[0-9]+$", RegexOptions.IgnoreCase);
            return match.Success;
        }

        /// <summary>
        /// Matching all capital letters in the input and seperate them with spaces to form a sentence.
        /// If the input is an abbreviation text, no space will be added and returns the same input.
        /// </summary>
        /// <example>
        /// input : HelloWorld
        /// output : Hello World
        /// </example>
        /// <example>
        /// input : BBC
        /// output : BBC
        /// </example>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSentence(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;
            //return as is if the input is just an abbreviation
            if (Regex.Match(input, "[0-9A-Z]+$").Success)
                return input;
            //add a space before each capital letter, but not the first one.
            var result = Regex.Replace(input, "(\\B[A-Z])", " $1");
            return result;
        }
        
        /// <summary>
        /// Mirror Value Effect
        /// </summary>
        /// <example>
        /// in: mirror effect string
        /// out: gnirts tceffe rorrim
        /// </example>
        public static string MirrorValue(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }

        /// <summary>
        /// Check if is number string
        /// </summary>
        /// <example>
        /// Reverse string chars
        /// </example>
        public static string ReverseSentence(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            input = input.TrimAndReduce();
            var split = input.Split(' ');
            Array.Reverse(split);
            return String.Join(" ",split);
        }


        /// <summary>
        /// Formats the string according to the specified mask
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="mask">The mask for formatting. Like "A##-##-T-###Z"</param>
        /// <returns>The formatted string</returns>
        public static string FormatWithMask(this string input, string mask)
        {
            var output = string.Empty;
            var index = 0;
            foreach (var m in mask)
            {
                if (m == '#')
                {
                    if (index < input.Length)
                    {
                        output += input[index];
                        index++;
                    }
                }
                else
                    output += m;
            }
            return output;
        }
       
        /// <summary>
        /// Converts a string into a "SecureString"
        /// </summary>
        public static System.Security.SecureString ToSecureString(this String str)
        {
            System.Security.SecureString secureString = new System.Security.SecureString();
            foreach (Char c in str)
                secureString.AppendChar(c);

            return secureString;
        }

        /// <summary>
        /// Stripe htmls
        /// </summary>
        public static string StripHtml(this string input)
        {
            // Will this simple expression replace all tags???
            var tagsExpression = new Regex(@"</?.+?>");
            return tagsExpression.Replace(input, " ").TrimAndReduce();
        }
        /// <summary>
        /// Convert to encoded Base64 String
        /// </summary>
        public static string Base64Encode(this string texto)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(texto);
            return System.Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// Convert to decoded Base64 String
        /// </summary>
        public static string Base64Decode(this string base64texto)
        {
            var bytes = System.Convert.FromBase64String(base64texto);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Change Simple quotes to Double quotes
        /// '' => ""
        /// </summary>
        public static string QuotesToDoubleQuotes(this string texto)
        {
            if (texto.IndexOf("'") != -1)
            {
                texto = texto.Replace("'", "\"").Trim();
            }
            return texto;
        }

        /// <summary>
        /// Change Double quotes to Simple quotes
        /// "" => ''
        /// </summary>
        public static string QuotesToSimpleQuotes(this string texto)
        {
            if (texto.IndexOf("\"") != -1)
            {
                texto = texto.Replace("\"", "\'").Trim();
            }
            return texto;
        }
   
    }
}
