using System.Web;
using System.Web.Optimization;

namespace FIT5120___VicEnerG
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Style/css").Include(
                      "~/Style/bootstrap.css"
                      ));

            bundles.Add(new StyleBundle("~/Pages_Resource/css/pagecss").Include(
                      "~/Pages_Resource/css/bootstrap.min.css",
                      "~/Pages_Resource/css/style.css",
                      "~/Pages_Resource/css/font-awesome.min.css",
                      "~/Pages_Resource/css/lsb.css",
                      "~/Pages_Resource/css/owl.carousel.css",
                      "~/Pages_Resource/css/flexslider.css"
                      ));

            bundles.Add(new ScriptBundle("~/Pages_Resource/js/pagejs").Include(
                      "~/Pages_Resource/js/bootstrap.min.js",
                      "~/Pages_Resource/js/easing.js",
                      "~/Pages_Resource/js/jquery-2.1.4.min.js",
                      "~/Pages_Resource/js/jquery.flexisel.js",
                      "~/Pages_Resource/js/jquery.flexslider.js",
                      "~/Pages_Resource/js/lsb.min.js",
                      "~/Pages_Resource/js/move-top.js",
                      "~/Pages_Resource/js/owl.carousel.js",
                      "~/Pages_Resource/js/SmoothScroll.min.js",
                      "~/Pages_Resource/js/pagejs.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/chartjs").Include(
              "~/Scripts/Chart.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/chartjsLabel").Include(
              "~/Scripts/chartjs-plugin-labels.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
