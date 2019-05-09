using Android.App;
using Android.OS;
using liderofertas.AppPresenters.PresenterDialog;
using liderofertas.AppUtils;

namespace liderofertas.AppDialogs
{
    /// <summary>
    /// Productos pasillo dialog.
    /// </summary>
    [Activity(Theme = "@style/ThemeNoActionBarBienvenida", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ProductosPasilloDialog : Activity
    {
        static Dialog customDialog = null;

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dialog_productos_pasillo);
        }

        /// <summary>
        /// Views the dialogo productos pasillo.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void ViewDialogoProductosPasillo(Activity activity, bool IsFromBeacons)
        {
            ProductosPasilloPresenter.ViewMensajeDialogo(activity, customDialog, IsFromBeacons);
        }

        /// <summary>
        /// Ons the back pressed.
        /// </summary>
        public override void OnBackPressed(){}
    }
}
