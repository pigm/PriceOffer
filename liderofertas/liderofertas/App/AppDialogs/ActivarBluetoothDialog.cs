using Android.App;
using Android.OS;
using liderofertas.AppPresenters.PresenterDialog;

namespace liderofertas.AppDialogs
{
    /// <summary>
    /// Activar bluetooth dialog.
    /// </summary>
    [Activity(Theme = "@style/ThemeNoActionBarBienvenida", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivarBluetoothDialog : Activity
    {
        static Dialog customDialog = null;
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dialog_activa_bluetooth);
        }

        /// <summary>
        /// Views the dialogo activar bluetooth.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void ViewDialogoActivarBluetooth(Activity activity)
        {
            ActivarBluetoothPresenter.ViewMensajeDialogo(activity, customDialog);
        }
    }
}
