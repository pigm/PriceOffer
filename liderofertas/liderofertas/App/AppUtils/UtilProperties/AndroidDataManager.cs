using System.Collections.Generic;
using Android.App;
using Android.Views;
using Estimote.Android.Proximity;

namespace liderofertas.AppUtils
{
    /// <summary>
    /// Android data manager.
    /// </summary>
    public class AndroidDataManager
    {
        /// <summary>
        /// Gets or sets the VGF ragment zonas ofertas.
        /// </summary>
        /// <value>The VGF ragment zonas ofertas.</value>
        public static ViewGroup VGFragmentZonasOfertas { get; set; }
        public static IProximityZoneContext ContextProximity { get; set; }
        public static Dialog CustomDialog { get; set; }
        public static Dialog CustomDialogViewOffer { get; set; }
        public static Dialog CustomDialogProductosPasillo { get; set; }
        public static List<ProductosOfertasModelAndroid> ProductosOfertas { get; set; }
        public static ProductosOfertasModelAndroid ProductoOferta { get; set; }
        public static List<PasilloModelAndroid> Pasillos { get; set; }
        public static ProductoModelAndroid ProductoPasillo { get; set; }
        public static List<ProductoModelAndroid> TotalProductosPasillo = new List<ProductoModelAndroid>();
        public static List<ProductoModelAndroid> ProductosXsubcategoria { get; set; }
        public static Subcategoria SubCategoriaXsubcategoria { get; set; }
        public static List<ZonaPasillo> ZonasPasillos { get; set; }
        public static List<Subcategoria> SubCategoriasFiltros = new List<Subcategoria>();
        public static List<ProductosOfertasUnicasModelAndroid> ProductosOfertasUnicas { get; set; }
        public static string TagIdentificator { get; set; }
        public static bool StateContextProximity { get; set; }
        public static bool AppCenterActive { get; set; }
    }
}
