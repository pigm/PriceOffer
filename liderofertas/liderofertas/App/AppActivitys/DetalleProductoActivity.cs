using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using liderofertas.AppFragments;

namespace liderofertas.AppActivitys
{
    /// <summary>
    /// Detalle producto activity.
    /// </summary>
    [Activity(Theme = "@style/ThemeNoActionBarWhite", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class DetalleProductoActivity : AppCompatActivity
    {
        Android.Support.V4.App.FragmentTransaction ft;
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_producto_detallado);
            ft = SupportFragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.linear_wrapper_producto, new FragmentDetalleProducto(SupportFragmentManager));
            ft.Commit();
        }

        /// <summary>
        /// Ons the back pressed.
        /// </summary>
        public override void OnBackPressed(){ StartActivity(new Intent(this, typeof(HomeOfertasActivity))); }
    }
}