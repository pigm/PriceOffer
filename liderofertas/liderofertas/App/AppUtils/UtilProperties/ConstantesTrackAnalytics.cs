using System;
namespace liderofertas.App.AppUtils.UtilProperties
{
    /// <summary>
    /// Constantes track analytics.
    /// </summary>
    public class ConstantesTrackAnalytics
    {
        public const string CATEGORY = "Category";
        public const string ACTION = "Action";
        public const string InTitleTrackAnalytics  = "Invoke Enter Proximity Zone";
        public const string OutTitleTrackAnalytics = "Invoke Exit  Proximity Zone";
        public const string ErrTitleTrackAnalytics = "Invoke Error Proximity Zone";

        public static string ErrCategoryTrackAnalytics = "Error Invoke beacon " + DateTime.Now;

        public const string InActionTrackAnalytics  = "Beacon In";
        public const string OutActionTrackAnalytics = "Beacon Out";
        public const string ErrActionTrackAnalytics = "Beacon Err";


    }
}
