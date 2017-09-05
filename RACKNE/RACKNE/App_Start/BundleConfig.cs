using System.Web;
using System.Web.Optimization;

namespace RACKNE
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //            "~/assets/js/bootstrap.js",
            //            "~/assets/js/Chart.js"));

            //bundles.Add(new ScriptBundle("~/bundles/fotorama").Include(
            //            "~/assets/js/fotorama.js"));

            bundles.Add(new ScriptBundle("~/bundle/scripts").Include(
                "~/Scripts/jquery-{version}.js",
                "~/assets/js/bootstrap.js",
                "~/assets/js/Chart.js",
                "~/assets/js/fotorama.js"));


            //bundles.Add(new StyleBundle("~/Content/fotorama").Include("~/assets/css/fotorama.css"));

            //bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/assets/css/bootstrap.css"));

            //bundles.Add(new StyleBundle("~/Content/font").Include("~/assets/css/font-awesome.css"));

            //bundles.Add(new StyleBundle("~/Content/main").Include("~/assets/css/main.css"));

            //bundles.Add(new StyleBundle("~/Content/css").Include("~/assets/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/style").Include("~/assets/Content/site.css",
                "~/assets/css/bootstrap.css",
                "~/assets/css/font-awesome.css",
                "~/assets/css/main.css",
                "~/assets/css/fotorama.css"));

            
        }
    }
}