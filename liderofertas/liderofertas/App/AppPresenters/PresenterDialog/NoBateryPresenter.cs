using System;
using Android.App;
using Android.Widget;

namespace liderofertas.AppPresenters.PresenterDialog
{
    /// <summary>
    /// No batery presenter.
    /// </summary>
    public class NoBateryPresenter
    {
        /// <summary>
        /// Views the mensaje dialogo.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="customDialog">Custom dialog.</param>
        /// <param name="mensaje">Mensaje.</param>
        public static void ViewMensajeDialogo(Activity activity, Dialog customDialog, string mensaje)
        {
            customDialog = new Dialog(activity, Resource.Style.MyThemeTranslucent);
            customDialog.SetCancelable(false);
            customDialog.SetContentView(Resource.Layout.dialog_no_batery);
            TextView lblMensajeError = customDialog.FindViewById<TextView>(Resource.Id.lblMensajeError);
            lblMensajeError.Text = mensaje;
            Button btnAceptarError = customDialog.FindViewById<Button>(Resource.Id.btnAceptarError);         
            btnAceptarError.Click += delegate {
                    customDialog.Dismiss();
            };
            customDialog.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            customDialog.Show();
        }
    }
}
