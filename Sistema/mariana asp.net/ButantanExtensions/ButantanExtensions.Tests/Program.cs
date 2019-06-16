using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
namespace ButantanExtensions.Tests
{

    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            String v = "";
            v = "rafael pt dos 3123123 asd -- `` %% 34234";
            System.Console.WriteLine(v.CapitalizeName());
            System.Console.WriteLine(v.CapitalizeBrazilianName());
            System.Console.WriteLine(v.MirrorValue());
            System.Console.WriteLine(v.ReverseSentence());
            System.Console.WriteLine(("mirror effect string").MirrorValue());
            var htmlText = "<p>Here is some text. <span class=\"bold\">This is bold.</span><br/> Talk to you later.</p>";
            System.Console.WriteLine(htmlText.StripHtml());
            System.Console.WriteLine("para simples \"\"".QuotesToSimpleQuotes());
            System.Console.WriteLine("para duplas ''".QuotesToDoubleQuotes());
           
            int integere = 0;
            v = "1.0.0";
            System.Console.WriteLine(v);
            while (integere < 100) {
                v = AumentarVersao(v); 
                System.Console.WriteLine(v);
                integere++;
            }
        }
        public static String AumentarVersao(String v)
        {
            var version = Version.Parse(v);

            int maior = version.Major;
            int menor = version.Minor;
            int comp = version.Build;

            if (comp == 9)
            {
                comp = 0;
                if (menor == 9)
                {
                    menor = 0;
                    maior++;
                }
                else
                {
                    menor++;
                }
            }
            else {
                comp++;
            }
            
            return new Version(maior, menor, comp).ToString();
        }

    }
}
