using Android.App;
using Android.OS;
using liderofertas.AppPresenters.PresenterDialog;

namespace liderofertas.AppDialogs
{
    /// <summary>
    /// No batery dialog.
    /// </summary>
    [Activity(Theme = "@style/ThemeNoActionBarBienvenida", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class NoBateryDialog : Activity
    {
        static Dialog customDialog = null;

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dialog_no_batery);
        }

        /// <summary>
        /// Views the dialogo mensaje no batery.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="mensaje">Mensaje.</param>
        /// <param name="estado">If set to <c>true</c> estado.</param>
        public static void ViewDialogoMensajeNoBatery(Activity activity, string mensaje){ NoBateryPresenter.ViewMensajeDialogo(activity, customDialog, mensaje); }
    }
}