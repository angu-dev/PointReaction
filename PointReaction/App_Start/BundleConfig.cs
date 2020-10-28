using System.Web;
using System.Web.Optimization;

namespace PointReaction
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/librarys").Include(
                "~/Scripts/jquery-3.4.1.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/bootstrap.bundle.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/defaultScripts").Include(
                "~/Scripts/default.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/defaultStyles").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/default.css"
            ));
        }
    }
}
