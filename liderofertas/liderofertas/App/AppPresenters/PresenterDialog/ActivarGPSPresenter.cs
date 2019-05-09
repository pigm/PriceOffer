using System;
using Android.App;
using Android.Content;
using Android.Widget;

namespace liderofertas.AppPresenters.PresenterDialog
{
    /// <summary>
    /// Activar GPSP resenter.
    /// </summary>
    public class ActivarGPSPresenter
    {
        /// <summary>
        /// Views the mensaje dialogo.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="customDialog">Custom dialog.</param>
        public static void ViewMensajeDialogo(Activity activity, Dialog customDialog)
        {
            customDialog = new Dialog(activity, Resource.Style.MyThemeTranslucent);
            customDialog.SetCancelable(false);
            customDialog.SetContentView(Resource.Layout.dialog_activa_gps);
            Button btnActivarGps = customDialog.FindViewById<Button>(Resource.Id.btnActivarGps);
            btnActivarGps.Click += delegate { ActivarGPSPresenter.ActivarGPS(activity, customDialog); };
            customDialog.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            customDialog.Show();
        }

        /// <summary>
        /// Activars the gps.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="customDialog">Custom dialog.</param>
        private static void ActivarGPS(Activity activity, Dialog customDialog)
        {
            customDialog.Dismiss();
            activity.StartActivity(new Intent(Android.Provider.Settings.ActionLocationSourceSettings));
        }
    }
}
