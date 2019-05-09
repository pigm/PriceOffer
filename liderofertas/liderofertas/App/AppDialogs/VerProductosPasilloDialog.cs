using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using liderofertas.AppPresenters.PresenterDialog;

namespace liderofertas.AppDialogs
{
    /// <summary>
    /// Ver productos pasillo dialog.
    /// </summary>
    [Activity(Theme = "@style/ThemeNoActionBarBienvenida", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class VerProductosPasilloDialog : Activity
    {
        static Dialog customDialog = null;

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dialog_ver_productospasillo);
        }

        /// <summary>
        /// Views the dialogo ver productos pasillo.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void ViewDialogoVerProductosPasillo(Activity activity)
        {
            VerProductosPasilloPresenter.ViewMensajeDialogo(activity, customDialog);
        }
    }
}