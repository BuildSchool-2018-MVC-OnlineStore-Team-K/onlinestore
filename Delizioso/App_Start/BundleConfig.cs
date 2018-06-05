using System.Web;
using System.Web.Optimization;

namespace WebApplication1
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/assets/css/css").Include(
                      "~/Content/assets/css/normalize.css",
                      "~/Content/assets/css/bootstrap.min.css",
                      "~/Content/assets/css/font-awesome.min.css",
                      "~/Content/assets/css/themify-icons.css",
                      "~/Content/assets/css/flag-icon.min.css",
                      "~/Content/assets/css/cs-skin-elastic.css"));

            bundles.Add(new StyleBundle("~/Content/assets/scss/css").Include(
                      "~/Content/assets/scss/widgets.css",
                      "~/Content/assets/scss/style.css"));

            bundles.Add(new StyleBundle("~/Content/Delizioso_files/css").Include(
                "~/Content/Delizioso_files/default.css",
                "~/Content/Delizioso_files/main.css",
                "~/Content/Delizioso_files/menu.css",
                "~/Content/Delizioso_files/jquery.cycle2.css",
                "~/Content/Delizioso_files/cart.css"));

            bundles.Add(new ScriptBundle("~/Content/Delizioso_files/js").Include(
                "~/Content/Delizioso_files/jquery-1.11.2.min.js.下載" ,
                "~/Content/Delizioso_files/polyfiller.min.js.下載" ,
                "~/Content/Delizioso_files/jquery.placeholder.min.js.下載" ,
                "~/Content/Delizioso_files/jquery.cycle2.min.js.下載"));

            bundles.Add(new StyleBundle("~/Content/styles/css").Include(
                "~/Content/styles/style.css"));
        }
    }
}
