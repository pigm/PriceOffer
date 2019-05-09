using System;
using System.Collections.Generic;
using Estimote.Android.Proximity;
using liderofertas.App.AppUtils.UtilAndroid;
using liderofertas.App.AppUtils.UtilProperties;
using Microsoft.AppCenter.Analytics;

namespace liderofertas.AppUtils
{
    /// <summary>
    /// My exit handler.
    /// </summary>
    public class MyExitHandler : Java.Lang.Object, Kotlin.Jvm.Functions.IFunction1
    {
        /// <summary>
        /// Invoke the specified p0.
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="p0">P0.</param>
        public Java.Lang.Object Invoke(Java.Lang.Object p0)
        {
            IProximityZoneContext context = (IProximityZoneContext)p0;
            AndroidDataManager.ContextProximity = context;
            AnalyticService.TrackAnalytics(ConstantesTrackAnalytics.OutTitleTrackAnalytics, new Dictionary<string, string> {
                                        { ConstantesTrackAnalytics.CATEGORY, InfoAndroid.GetNameModel + " -- " + context.Tag + " -- " + DateTime.Now },
                                        { ConstantesTrackAnalytics.ACTION  , ConstantesTrackAnalytics.OutActionTrackAnalytics}
                                    });
            return null;
        }
    }
}
