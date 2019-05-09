using Android.App;
using Android.OS;
using Android.Widget;
using liderofertas.AppPresenters.PresenterActivity;

namespace liderofertas.AppActivitys
{
    /// <summary>
    /// Enrolamiento datos activity.
    /// </summary>
    [Activity(Theme = "@style/ThemeNoActionBarBienvenida", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class EnrolamientoDatosActivity : Activity
    {
        Button btnContinuar, btnVolver;
        EditText txtEdad;
        LinearLayout llDescripcionLocal, llBtnPlace;
        Spinner spiSexo;
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_enrolamiento_datos);
            btnContinuar = FindViewById<Button>(Resource.Id.btnContinuar);
            btnVolver = FindViewById<Button>(Resource.Id.btnVolver);
            txtEdad = FindViewById<EditText>(Resource.Id.txtEdad);
            llDescripcionLocal = FindViewById<LinearLayout>(Resource.Id.llDescripcionLocal);
            llBtnPlace = FindViewById<LinearLayout>(Resource.Id.llBtnPlace);
            spiSexo = FindViewById<Spinner>(Resource.Id.spiSexo);

        }

        /// <summary>
        /// Ons the resume.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            EnrolamientoDatosPresenter.GoneLocal(llDescripcionLocal, llBtnPlace);
            EnrolamientoDatosPresenter.CargaSpinner(this, spiSexo);
            btnContinuar.Click += delegate { EnrolamientoDatosPresenter.BtnContinuar(this, txtEdad, 1); };
            btnVolver.Click += delegate { EnrolamientoDatosPresenter.BtnVolver(this); };
        }

        /// <summary>
        /// Ons the back pressed.
        /// </summary>
        public override void OnBackPressed(){ EnrolamientoDatosPresenter.BtnVolver(this); }
    }
}