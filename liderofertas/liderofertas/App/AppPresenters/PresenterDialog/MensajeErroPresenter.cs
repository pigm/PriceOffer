using System;
using Android.App;
using Android.Content;
using Android.Widget;
using liderofertas.AppActivitys;

namespace liderofertas.AppPresenters.PresenterDialog
{
    /// <summary>
    /// Mensaje erro presenter.
    /// </summary>
    public class MensajeErroPresenter
    {
        /// <summary>
        /// Views the mensaje dialogo.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="customDialog">Custom dialog.</param>
        /// <param name="mensaje">Mensaje.</param>
        /// <param name="estado">If set to <c>true</c> estado.</param>
        public static void ViewMensajeDialogo(Activity activity, Dialog customDialog, string mensaje, bool estado)
        {
            customDialog = new Dialog(activity, Resource.Style.MyThemeTranslucent);
            customDialog.SetCancelable(false);
            customDialog.SetContentView(Resource.Layout.dialog_mensaje_error);
            TextView lblMensajeError = customDialog.FindViewById<TextView>(Resource.Id.lblMensajeError);
            lblMensajeError.Text = mensaje;
            Button btnAceptarError = customDialog.FindViewById<Button>(Resource.Id.btnAceptarError);         
            btnAceptarError.Click += delegate {
                if (estado)               
                    activity.StartActivity(new Intent(activity, typeof(HomeOfertasActivity)));
                else
                    customDialog.Dismiss();
            };
            customDialog.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            customDialog.Show();
        }
    }
}
