using System;
using System.Diagnostics;
using System.Web.Optimization;

namespace IXL
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScriptBundles(bundles);
            RegisterStyleBundles(bundles);

            BundleTable.EnableOptimizations = !Debugger.IsAttached;
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/layout").Include(
                  "~/content/style.css",
                  "~/content/shortcodes.css",
                  "~/content/responsive.css",
                  "~/content/font-awesome.min.css",
                  "~/content/prettyPhoto.css"));
        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/layout").Include(
                "~/Scripts/jquery-{version}.js",
                //"~/Scripts/jquery.js",
                "~/Scripts/jquery-migrate.min.js",
                "~/Scripts/jquery.tabs.min.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery-easing-{version}.js",
                "~/Scripts/jquery.sticky.js",
                "~/Scripts/jquery.nicescroll.min.js",
                "~/Scripts/jquery.inview.js",
                "~/Scripts/validation.js",
                "~/Scripts/jquery.tipTip.minified.js",
                "~/Scripts/jquery.prettyPhoto.js",
                "~/Scripts/twitter/jquery.tweet.min.js",
                "~/Scripts/shortcodes.js",
                "~/Scripts/custom.js"));



            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));
        }
    }
}
