using System;
using Android.App;
using Android.Media;
using Android.Widget;
using liderofertas.AppDialogs;
using liderofertas.AppUtils;

namespace liderofertas.AppPresenters.PresenterDialog
{
    /// <summary>
    /// Ver productos pasillo presenter.
    /// </summary>
    public class VerProductosPasilloPresenter
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
            customDialog.SetContentView(Resource.Layout.dialog_ver_productospasillo);
            Button btnCancelarVerProductoPasillo = customDialog.FindViewById<Button>(Resource.Id.btnCancelarVerProductoPasillo);
            Button btnVerProductoPasillo = customDialog.FindViewById<Button>(Resource.Id.btnVerProductoPasillo);
            btnCancelarVerProductoPasillo.Click += delegate { customDialog.Dismiss(); AndroidDataManager.CustomDialogViewOffer = null; GC.Collect(); };
            btnVerProductoPasillo.Click += delegate { customDialog.Dismiss(); ProductosPasilloDialog.ViewDialogoProductosPasillo(activity, true); };
            customDialog.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            customDialog.Show();
            StartPlayer(activity);           
            AndroidDataManager.CustomDialogViewOffer = customDialog;
        }

        static MediaPlayer player ;
        public static void StartPlayer(Activity activity)
        {
            try
            {
                var mplayer = player ?? MediaPlayer.Create(activity.ApplicationContext, Resource.Raw.hangouts_message);
                mplayer.Start();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}