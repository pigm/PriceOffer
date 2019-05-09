using Android.App;
using Android.OS;
using liderofertas.AppPresenters.PresenterActivity;
using liderofertas.AppUtils;
using liderofertas.AppUtils.UtilAndroid;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace liderofertas
{
    /// <summary>
    /// Main activity.
    /// </summary>
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.splash);
            try{
                AppCenter.Start("40189672-b6c9-4185-9b59-cfd8a7a7f19f", typeof(Analytics), typeof(Crashes));
                AndroidDataManager.AppCenterActive = true;
            }catch{
                AndroidDataManager.AppCenterActive = false;
            }

            await DownloadProductOffer.Instance.DoInBackground(this);
            MainPresenter.InicioApp(this);
        }

        /// <summary>
        /// Ons the back pressed.
        /// </summary>
        public override void OnBackPressed(){}
    }
}