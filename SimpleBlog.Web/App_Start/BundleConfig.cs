using System.Web.Optimization;

namespace SimpleBlog.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css")
                .Include("~/Content/bootstrap/dist/css/bootstrap.css")
                .Include("~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/js")
                .Include("~/Content/jquery/dist/jquery.js")
                .Include("~/Content/bootstrap/dist/js/bootstrap.js"));
        }
    }
}