using Android.App;
using Android.OS;
using liderofertas.AppPresenters.PresenterDialog;

namespace liderofertas.AppDialogs
{
    /// <summary>
    /// Activar gps dialog.
    /// </summary>
    [Activity(Theme = "@style/ThemeNoActionBarBienvenida", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivarGpsDialog : Activity
    {
        static Dialog customDialog = null;

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState){ base.OnCreate(savedInstanceState); SetContentView(Resource.Layout.dialog_activa_gps); }

        /// <summary>
        /// Views the dialogo activar gps.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void ViewDialogoActivarGPS(Activity activity){ ActivarGPSPresenter.ViewMensajeDialogo(activity, customDialog); }
    }
}