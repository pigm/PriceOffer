using System.Collections.Generic;
using liderofertas.AppUtils;
using Microsoft.AppCenter.Analytics;
namespace liderofertas.App.AppUtils.UtilAndroid
{
    /// <summary>
    /// Analytic service.
    /// </summary>
    public class AnalyticService
    {
        /// <summary>
        /// Tracks the analytics.
        /// </summary>
        /// <param name="eventClass">Event class.</param>
        /// <param name="dictionary">Dictionary.</param>
        public static void TrackAnalytics(string eventClass, Dictionary<string, string> dictionary)
        {
            if (AndroidDataManager.AppCenterActive)
                Analytics.TrackEvent(eventClass, dictionary);
        }
    }
}
