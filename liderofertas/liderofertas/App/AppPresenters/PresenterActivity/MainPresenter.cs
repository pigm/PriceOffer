using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Util;
using liderofertas.AppActivitys;
using liderofertas.AppUtils;

namespace liderofertas.AppPresenters.PresenterActivity
{
    /// <summary>
    /// Main presenter.
    /// </summary>
    public class MainPresenter
    {
        /// <summary>
        /// Inicios the app.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void InicioApp(Activity activity)
        {
            try{
                Task startupwork = new Task(() =>
                {
                    Task.Delay(5000).Wait();
                });
                startupwork.ContinueWith(t =>
                {
                   activity.StartActivity(new Intent(activity, typeof(BienvenidaActivity)));
                }, TaskScheduler.FromCurrentSynchronizationContext());

                startupwork.Start();
            }
            catch (Exception ex){
                Log.Info("start app ", ex.Message);
            }
        }
    }
}
