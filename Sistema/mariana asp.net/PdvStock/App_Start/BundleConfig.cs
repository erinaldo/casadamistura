using System.Web;
using System.Web.Optimization;

namespace PdvStock
{
    public class BundleConfig
    {
        // Para mais informações sobre o agrupamento, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para produzir, utilize a ferramenta de compilação em http://modernizr.com para selecionar apenas os testes de que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/gridmvc.js",
                      "~/Scripts/chosen.jquery.min.js",
                      "~/Scripts/jquery.inputmask/jquery.inputmask.js",
                      "~/Scripts/bootstrap-datepicker.min.js",
                      "~/Scripts/bootstrap-datepicker-globalize.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/visibilidadeMobile.css",
                      "~/Content/Gridmvc.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/bootstrap-datepicker3.css",
                      "~/Content/awesome-bootstrap-checkbox.css",
                      "~/Content/chosen.min.css",
                      "~/Content/Style.css"
                      ));
            bundles.Add(new ScriptBundle("~/Scripts/sidebar").Include(
                        "~/Scripts/side.js"
                     ));
            bundles.Add(new StyleBundle("~/Content/sidebar").Include(
                        "~/Content/side.css"
                     ));
            bundles.Add(new ScriptBundle("~/bundles/layout").Include(
                    "~/Scripts/ConfigLayout.js"
                ));
            BundleTable.EnableOptimizations = false;
        }
    }
}
