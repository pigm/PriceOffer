using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Android.Util;
using Estimote.Android.Proximity;
using liderofertas.App.AppUtils.UtilAndroid;
using liderofertas.App.AppUtils.UtilProperties;
using liderofertas.AppActivitys;
using Microsoft.AppCenter.Analytics;

namespace liderofertas.AppUtils
{
    /// <summary>
    /// My enter handler.
    /// </summary>
    public class MyEnterHandler : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
    {
        HomeOfertasActivity ma;
        string channel;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Example.Android.Proximity.MainActivity.MyEnterHandler"/> class.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="channel">Channel.</param>
        public MyEnterHandler(HomeOfertasActivity activity, string channel)
        {
            this.ma = activity;
            this.channel = channel;
        }

        /// <summary>
        /// Invoke the specified p0.
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="p0">P0.</param>
        public Java.Lang.Object Invoke(Java.Lang.Object p0)
        {
            IProximityZoneContext context = (IProximityZoneContext)p0;          
            AndroidDataManager.ContextProximity = context;
            AndroidDataManager.TagIdentificator = context.Tag;
            ma.NotificaOferta(context);
            AnalyticService.TrackAnalytics(ConstantesTrackAnalytics.InTitleTrackAnalytics, new Dictionary<string, string> {
                                        { ConstantesTrackAnalytics.CATEGORY, InfoAndroid.GetNameModel + " -- " + context.Tag + " -- " + DateTime.Now },
                                        { ConstantesTrackAnalytics.ACTION  , ConstantesTrackAnalytics.InActionTrackAnalytics}
                                    });
            return null;
        }
    }
}