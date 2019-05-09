using Android.App;
using Android.OS;
using liderofertas.AppPresenters.PresenterDialog;

namespace liderofertas.AppDialogs
{
    /// <summary>
    /// Mensaje error dialog.
    /// </summary>
    [Activity(Theme = "@style/ThemeNoActionBarBienvenida", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MensajeErrorDialog : Activity
    {
        static Dialog customDialog = null;
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dialog_mensaje_error);
        }

        /// <summary>
        /// Views the dialogo mensaje error.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="mensaje">Mensaje.</param>
        public static void ViewDialogoMensajeError(Activity activity, string mensaje, bool estado)
        {
            MensajeErroPresenter.ViewMensajeDialogo(activity, customDialog, mensaje, estado);
        }
    }
}
