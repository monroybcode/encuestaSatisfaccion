using System.Web;
using System.Web.Optimization;

namespace EncuestaSatisfaccion
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/pnotify.custom.min.css",
                       "~/Content/select2.min.css",
                       "~/Content/dataTables.bootstrap4.min.css",
                       "~/Content/responsive.bootstrap4.min.css",
                       "~/Content/responsive.dataTables.min.css",
                       "~/Content/buttons.dataTables.min.css",
                       "~/Content/fixedColumns.dataTables.min.css"
                       //"~/Scripts/Chart.min.css"
               ));

            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                     "~/Scripts/jquery-3.3.1.min.js",
                     "~/Scripts/node_modules/jquery/dist/jquery.min.js",
                     "~/Scripts/node_modules/bootstrap/dist/js/bootstrap.min.js",
                     "~/Scripts/node_modules/coreui/coreui/dist/js/coreui.min.js",
                     "~/Scripts/select2.min.js",
                     "~/Scripts/jquery.dataTables.min.js",
                     "~/Scripts/dataTables.bootstrap4.min.js",
                     "~/Scripts/dataTables.responsive.min.js",
                     "~/Scripts/pnotify.custom.min.js",
                     "~/Scripts/fnFindCellRowIndexes.js",
                    "~/Scripts/dataTables.rowGroup.min.js",
                     "~/Scripts/dataTables.buttons.min.js",
                      "~/Scripts/buttons.print.min.js",
                       "~/Scripts/buttons.html5.min.js",
                      "~/Scripts/buttons.flash.min.js",
                      "~/Scripts/jszip.min.js",
                     "~/Scripts/pdfmake.min.js",
                     "~/Scripts/vfs_fonts.js",
                    "~/Scripts/buttons.colVis.min.js",
                    "~/Scripts/buttons.html5.min.js",
                    "~/Scripts/dataTables.fixedColumns.min.js",
                     "~/Scripts/jquery.mask.min.js"
                     //"~/Scripts/jquery-barcode.js",

                     //"~/Scripts/JsBarcode.all.js",
                     //"~/Scripts/JsBarcode.all.min.js",
                     //"~/Scripts/Chart.min.js"
            ));
        }
    }
}
