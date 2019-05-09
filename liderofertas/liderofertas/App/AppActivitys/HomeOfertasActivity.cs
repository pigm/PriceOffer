using System;
using System.Collections.Generic;
using System.Linq;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Widget;
using Estimote.Android.Proximity;
using liderofertas.AppDialogs;
using liderofertas.AppPresenters.PresenterActivity;
using liderofertas.AppUtils;

namespace liderofertas.AppActivitys
{
    /// <summary>
    /// Home ofertas activity.
    /// </summary>
    [Activity(Theme = "@style/ThemeNoActionBarApp", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
             Android.Content.PM.ConfigChanges.Orientation,
             ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class HomeOfertasActivity : AppCompatActivity
    {
        IProximityObserver observer;
        IProximityObserverHandler observationHandler;
        IProximityZone zonePasilloLider;
        LinearLayout llBtnUser, llDescripcionLocal, llBtnPlace;
        List<IProximityZone> listZone;
        NotificationChannel chan1;
        string home;
        private const int NOTIFY_ID = 1100;
        private const int MY_PERMISSIONS_REQUEST_COARSE_LOCATION = 1;
        private const string CHANNEL_ID = "proximity_scanning";
        private const string APP_ESTIMOTE = "dsacproximity-49q";
        private const string APP_ESTIMOTE_TOKEN = "edd5e987e3788db37f8a9b745e76760e";
        private bool isBackground;

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_home_ofertas);
            home = Resources.GetString(Resource.String.home);
            llBtnUser = FindViewById<LinearLayout>(Resource.Id.llBtnUser);
            llDescripcionLocal = FindViewById<LinearLayout>(Resource.Id.llDescripcionLocal);
            llBtnPlace = FindViewById<LinearLayout>(Resource.Id.llBtnPlace);
            HomeOfertasPresenter.EnablesActionBarUser(llBtnUser);
            HomeOfertasPresenter.InflateFragment(SupportFragmentManager, home, llDescripcionLocal, llBtnPlace);
            RegistroEstimote();
        }

        private void RegistroEstimote()
        {
            #region ESTIMOTE
            var creds = new EstimoteCloudCredentials(APP_ESTIMOTE, APP_ESTIMOTE_TOKEN);
            listZone = new List<IProximityZone>();
            /*
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(CHANNEL_ID, "Ofertas en pasillos inteligentes de lider y express", NotificationImportance.Low);
                var notificationManager = this.GetSystemService(Context.NotificationService) as NotificationManager;
                notificationManager.CreateNotificationChannel(channel);
            }

            var notification = new NotificationCompat.Builder(this, CHANNEL_ID)
                    .SetSmallIcon(Resource.Mipmap.menu_lidercl)
                    .SetContentTitle("En supermercados Lider y express de lider")
                    .SetLargeIcon(BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.ic_notificationimg))
                    .SetContentText("hay ofertas siempre!!")
                    .SetColor(Resource.Color.colorAccent)
                    .Build(); 
            */

            observer = new ProximityObserverBuilder(ApplicationContext, creds)
                .WithBalancedPowerMode()
               // .WithScannerInForegroundService(notification)
                .WithEstimoteSecureMonitoringDisabled()
                .WithTelemetryReportingDisabled()
                .OnError(new MyErrorHandler(this, "err"))
                .Build();

            if (AndroidDataManager.Pasillos != null)
            {
                foreach (var item in AndroidDataManager.Pasillos)
                {
                    zonePasilloLider = new ProximityZoneBuilder()
                    .ForTag(item.tag)
                    .InCustomRange(2.2)
                    .OnEnter(new MyEnterHandler(this, CHANNEL_ID))
                    .OnExit(new MyExitHandler())
                    .Build();
                    listZone.Add(zonePasilloLider);
                }
            }
            #endregion
        }

        /// <summary>
        /// Ons the resume.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            isBackground = false;
            if (ContextCompat.CheckSelfPermission(
                this, Manifest.Permission.AccessCoarseLocation) != Permission.Granted)
            {
                if (ActivityCompat.ShouldShowRequestPermissionRationale(
                    this, Manifest.Permission.AccessCoarseLocation)){}

                ActivityCompat.RequestPermissions(
                        this ,new string[] { Manifest.Permission.AccessCoarseLocation }
                        ,MY_PERMISSIONS_REQUEST_COARSE_LOCATION);
            }
            else
            {
                StartProximityObservation();
            }

            Bundle parametros = this.Intent.Extras;
            if (parametros != null)
            {
               String datos = parametros.GetString("pasillo");
               VerProductosPasilloDialog.ViewDialogoVerProductosPasillo(this);
            }
        }

        /// <summary>
        /// Ons the pause.
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
            isBackground = true;
        }

        /// <summary>
        /// Ons the request permissions result.
        /// </summary>
        /// <param name="requestCode">Request code.</param>
        /// <param name="permissions">Permissions.</param>
        /// <param name="grantResults">Grant results.</param>
        public override void OnRequestPermissionsResult(
            int requestCode, string[] permissions, Permission[] grantResults)
        {
            switch (requestCode)
            {
                case MY_PERMISSIONS_REQUEST_COARSE_LOCATION:
                    {
                        if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                        {
                            StartProximityObservation();
                        }
                        else
                        {/*Log.Debug("app", "Permisos de Location denegados");*/}
                        return;
                    }
            }
        }

        /// <summary>
        /// Ons the back pressed.
        /// </summary>
        public override void OnBackPressed(){ StartActivity(new Intent(this, typeof(BienvenidaActivity))); Finish(); }

        /// <summary>
        /// Starts the proximity observation.
        /// </summary>
        void StartProximityObservation()
        {
            if (LocationUtils.IsGPSProvider(this) || LocationUtils.IsNetowrkProvider(this))
            {
                if (observationHandler != null)
                    return;

                if (!listZone.Any())
                {
                    RegistroEstimote();
                }
                observationHandler = observer.StartObserving(listZone);
            }
            else
            {
                ActivarGpsDialog.ViewDialogoActivarGPS(this);
            }


        }

        /// <summary>
        /// Ons the destroy.
        /// </summary>
        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (observationHandler != null)
                observationHandler.Stop();
        }

        /// <summary>
        /// Alerts the error handler.
        /// </summary>
        /// <param name="mensaje">Mensaje.</param>
        public void AlertErrorHandler(Java.Lang.Object mensaje)
        {
            Console.WriteLine("----------------------- ERROR DESCRIPTION ----------------------------");
            Console.WriteLine(mensaje.ToString());
            Console.WriteLine("----------------------- END ERROR DESCRIPTION ----------------------------");
            if (mensaje.ToString().Contains(ConstantesApp.CONTAINS_ENERGY_LOW))
                NoBateryDialog.ViewDialogoMensajeNoBatery(this, ConstantesApp.MSJ_ENERGY_LOW);
            //else
            //    MensajeErrorDialog.ViewDialogoMensajeError(this, ConstantesApp.MSJ_CONECTION_FAIL, false);
        }


        /// <summary>
        /// Notificas the oferta.
        /// </summary>
        /// <param name="context">Context.</param>
        public void NotificaOferta(IProximityZoneContext context)
        {
            if (isBackground) {
                SendPushNotification(context);
            }else{
                if (AndroidDataManager.CustomDialogProductosPasillo == null && AndroidDataManager.CustomDialogViewOffer == null){
                    VerProductosPasilloDialog.ViewDialogoVerProductosPasillo(this);
                }
            }
        }

        /// <summary>
        /// Sends the push notification.
        /// </summary>
        /// <param name="context">Context.</param>
        private void SendPushNotification(IProximityZoneContext context)
        {
            var intent = new Intent(this, typeof(HomeOfertasActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            intent.PutExtra("pasillo", context.Tag);
            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);
            string nombrePasillo = "";
            if (AndroidDataManager.Pasillos != null)
            {
                var pas = AndroidDataManager.Pasillos.Where(x => x.tag == context.Tag).FirstOrDefault();              
                nombrePasillo = "Estás en la zona de ofertas en el " + pas.nombrePasillo;
            }
            else
            {
                nombrePasillo = "Estás en una zona de ofertas";
            }
            var messageBody = nombrePasillo; 
            var notificationBuilder = new NotificationCompat.Builder(this, CHANNEL_ID)
                                                        .SetContentTitle("Lider Ofertas")
                                                        .SetSmallIcon(Resource.Mipmap.menu_lidercl)
                                                        .SetContentText(messageBody)
                                                        .SetAutoCancel(true)
                                                        .SetShowWhen(true)
                                                        .SetStyle(new NotificationCompat.BigTextStyle().BigText(messageBody))
                                                        .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManager.FromContext(this);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                chan1 = new NotificationChannel(CHANNEL_ID,
                                           "Lider Ofertas", NotificationImportance.High);
                chan1.LightColor = Color.Azure;
                chan1.LockscreenVisibility = NotificationVisibility.Public;
                notificationManager.CreateNotificationChannel(chan1);
                notificationBuilder.SetChannelId(CHANNEL_ID);
            }
            notificationManager.Notify(NOTIFY_ID, notificationBuilder.Build());//reemplazar por context.Tag
        }
    }
}