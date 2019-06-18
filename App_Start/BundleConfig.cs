using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BaseMvcParalax.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new ScriptBundle("~/scripts/all").Include(
                    "~/Template/vendor/jquery/jquery.min.js",
                "~/Template/vendor/jquery.appear/jquery.appear.min.js",
                "~/Template/vendor/jquery.easing/jquery.easing.min.js",
                "~/Template/vendor/jquery.cookie/jquery.cookie.min.js",
                "~/Template/vendor/popper/umd/popper.min.js",
                "~/Template/vendor/bootstrap/js/bootstrap.min.js",
                "~/Template/vendor/common/common.min.js",
                "~/Template/vendor/jquery.validation/jquery.validate.min.js",
                "~/Template/vendor/jquery.easy-pie-chart/jquery.easypiechart.min.js",
                "~/Template/vendor/jquery.gmap/jquery.gmap.min.js",
                "~/Template/vendor/jquery.lazyload/jquery.lazyload.min.js",
                "~/Template/vendor/isotope/jquery.isotope.min.js",
                "~/Template/vendor/owl.carousel/owl.carousel.min.js",
                "~/Template/vendor/magnific-popup/jquery.magnific-popup.min.js",
                "~/Template/vendor/vide/jquery.vide.min.js",
                "~/Template/vendor/vivus/vivus.min.js",
                "~/Template/js/theme.js", 
                "~/Template/vendor/rs-plugin/js/jquery.themepunch.tools.min.js",
                "~/Template/vendor/rs-plugin/js/jquery.themepunch.revolution.min.js",
                "~/Template/js/views/view.contact.js",
                 "~/Template/js/custom.js",
                 "~/Template/js/theme.init.js",
                 "~/Template/js/examples/examples.portfolio.js",
                 "~/Template/master/analytics/analytics.js"

               )
            );


            bundles.Add(new StyleBundle("~/theme/css").Include(
                "~/Template/css/theme.css",
                "~/Template/css/theme-elements.css",
                "~/Template/css/theme-blog.css",
                "~/Template/css/theme-shop.css")
            );


            bundles.Add(new StyleBundle("~/vendor/css").Include(
                "~/Template/vendor/bootstrap/css/bootstrap.min.css",
                "~/Template/vendor/fontawesome-free/css/all.min.css",
                "~/Template/vendor/animate/animate.min.css",
                "~/Template/vendor/simple-line-icons/css/simple-line-icons.min.css",
            "~/Template/vendor/owl.carousel/assets/owl.carousel.min.css",
                "~/Template/vendor/owl.carousel/assets/owl.theme.default.min.css",
                "~/Template/vendor/magnific-popup/magnific-popup.min.css",
                "~/Template/css/theme.css",
                "~/Template/css/theme-elements.css",
                "~/Template/css/theme-blog.css",
                "~/Template/css/theme-shop.css",
                "~/Template/vendor/rs-plugin/css/settings.css",
                "~/Template/vendor/rs-plugin/css/layers.css",
                "~/Template/vendor/rs-plugin/css/navigation.css",
                "~/Template/css/skins/default.css",
                "~/Template/css/custom.css"
                ));

            bundles.Add(new StyleBundle("~/current/css").Include(
                "~/Template/vendor/rs-plugin/css/settings.css",
                "~/Template/vendor/rs-plugin/css/layers.css",
                "~/Template/vendor/rs-plugin/css/navigation.css",
                "~/Template/css/skins/default.css",
                "~/Template/css/custom.css"
                ));

        }
    }
}