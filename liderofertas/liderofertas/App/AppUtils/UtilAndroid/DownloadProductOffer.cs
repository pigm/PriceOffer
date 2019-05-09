using System.Threading.Tasks;
using Android.App;

namespace liderofertas.AppUtils.UtilAndroid
{
    /// <summary>
    /// Download product offer.
    /// </summary>
    public class DownloadProductOffer : AsyncTask<Activity>
    {
        static DownloadProductOffer instance = null;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static DownloadProductOffer Instance
        {
            get
            {
                if (instance == null)
                    instance = new DownloadProductOffer();
                return instance;
            }
        }

        /// <summary>
        /// Dos the in background.
        /// </summary>
        /// <returns>The in background.</returns>
        /// <param name="activity">Activity.</param>
        public async Task DoInBackground(Activity activity)
        {
            await CargaProductos.CargaProductosOfertasCompanyAsync(activity);
            await CargaProductos.CargaOfertasUnicas(activity);
            await CargaProductos.CargaProductosPasillo(activity);
        }

        /// <summary>
        /// Ons the progress update.
        /// </summary>
        protected void OnProgressUpdate() {/*El metoddo hara una accion luego de comenzar la descarga por ejemplo mostrar un icono en statusbar de descargando con google play store*/}

        protected void OnPostExecute() { /*El metoddo hara una accion luego de terminar la descarga por ejemplo mostrar un dialogo descarga exitosa*/}
    }
}
