using System;
using System.Collections.Generic;
using liderofertas.App.AppUtils.UtilAndroid;
using liderofertas.App.AppUtils.UtilProperties;
using liderofertas.AppActivitys;
using Microsoft.AppCenter.Analytics;

namespace liderofertas.AppUtils
{
    /// <summary>
    /// My error handler.
    /// </summary>
    public class MyErrorHandler : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
    {
        HomeOfertasActivity ha;
        string channel;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Example.Android.Proximity.MainActivity.MyEnterHandler"/> class.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="channel">Channel.</param>
        public MyErrorHandler(HomeOfertasActivity activity, string channel)
        {
            this.ha = activity;
            this.channel = channel;
        }
        /// <summary>
        /// Invoke the specified throwable.
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="throwable">Throwable.</param>
        public Java.Lang.Object Invoke(Java.Lang.Object throwable)
        {
            ha.AlertErrorHandler(throwable);
            AnalyticService.TrackAnalytics(ConstantesTrackAnalytics.OutTitleTrackAnalytics, new Dictionary<string, string> {
                                        { ConstantesTrackAnalytics.CATEGORY,InfoAndroid.GetNameModel + " -- " + ConstantesTrackAnalytics.ErrCategoryTrackAnalytics },
                                        { ConstantesTrackAnalytics.ACTION, ConstantesTrackAnalytics.ErrActionTrackAnalytics}
                                    });
            return null;
        }
    }
}
