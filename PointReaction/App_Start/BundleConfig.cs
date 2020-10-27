using System.Web;
using System.Web.Optimization;

namespace PointReaction
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-3.5.1.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/defaultScripts").Include(
                "~/Scripts/default.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/defaultStyles").Include(
                "~/Content/default.css"
            ));
        }
    }
}
