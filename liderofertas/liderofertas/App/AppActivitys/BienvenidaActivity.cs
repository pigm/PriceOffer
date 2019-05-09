using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Widget;
using liderofertas.AppDialogs;
using liderofertas.AppPresenters.PresenterActivity;
using liderofertas.AppUtils;

namespace liderofertas.AppActivitys
{
    /// <summary>
    /// Bienvenida activity.
    /// </summary>
    [Activity(Theme = "@style/ThemeNoActionBarBienvenida", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class BienvenidaActivity : AppCompatActivity
    {
        EditText txtRut;
        LinearLayout llBtnIngresoRut;
        TextView btnIngresoAnonimo;

        /// <summary>
        /// The permissions location.
        /// </summary>
        readonly string[] PermissionsLocation = {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation,
            Manifest.Permission.AccessLocationExtraCommands,
            Manifest.Permission.AccessMockLocation,
            Manifest.Permission.AccessNetworkState,
            Manifest.Permission.AccessNotificationPolicy,
            Manifest.Permission.AccountManager,
            Manifest.Permission.Bluetooth,
            Manifest.Permission.BluetoothAdmin,
            Manifest.Permission.BluetoothPrivileged,
            Manifest.Permission.Camera,
            Manifest.Permission.ChangeNetworkState,
            Manifest.Permission.ChangeWifiState,
            Manifest.Permission.Internet,
        };

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_bienvenida);
            await GetLocationCompatAsync();
            txtRut = FindViewById<EditText>(Resource.Id.txtRut);
            llBtnIngresoRut = FindViewById<LinearLayout>(Resource.Id.llBtnIngresoRut);
            btnIngresoAnonimo = FindViewById<TextView>(Resource.Id.btnIngresoAnonimo);
        }

        protected override void OnResume()
        {
            base.OnResume();
            BienvenidaPresenter.MaskRut(this, txtRut);
            txtRut.TextChanged += delegate { BienvenidaPresenter.TextColorRutValid(this, txtRut); };
            llBtnIngresoRut.Click += delegate { BienvenidaPresenter.IngresoRut(this, txtRut, 1); };
            btnIngresoAnonimo.Touch += delegate { BienvenidaPresenter.IngresoAnonimo(this); };
        }

        /// <summary>
        /// Ons the back pressed.
        /// </summary>
        public override void OnBackPressed() { CloseAppDialog.ViewDialogoSalirApp(this); }

        /// <summary>
        /// Gets the location compat async.
        /// </summary>
        /// <returns>The location compat async.</returns>
        async Task GetLocationCompatAsync()
        {
            const string permission = Manifest.Permission.AccessFineLocation;
            if (ContextCompat.CheckSelfPermission(this, permission) == (int)Permission.Granted)
                return;

            if (ActivityCompat.ShouldShowRequestPermissionRationale(this, permission))
            {
                var dialog = new Android.Support.V7.App.AlertDialog.Builder(this).SetTitle(ConstantesApp.ACTION_REQUIRED)
                .SetMessage(ConstantesApp.REQUIRED_ACCESS_LOCATION)
                .SetPositiveButton(ConstantesApp.ACEPTAR, (senderAlert, args) =>
                { RequestPermissions(PermissionsLocation, ConstantesApp.RequestLocationId); }).Show();
                return;
            }
            RequestPermissions(PermissionsLocation, ConstantesApp.RequestLocationId);
        }

        /// <summary>
        /// Ons the request permissions result.
        /// </summary>
        /// <param name="requestCode">Request code.</param>
        /// <param name="permissions">Permissions.</param>
        /// <param name="grantResults">Grant results.</param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            switch (requestCode)
            {
                case ConstantesApp.RequestLocationId:
                {
                    if (grantResults[0] == (int)Permission.Granted)
                        Toast.MakeText(this, ConstantesApp.CON_PERMISOS, ToastLength.Short).Show();
                    else
                    {
                        Toast.MakeText(this, ConstantesApp.SIN_PERMISOS, ToastLength.Long).Show();
                        this.FinishAffinity();
                    }
                }
                break;
            }
        }
    }
}