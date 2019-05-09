using System;
using Android.OS;

namespace liderofertas.App.AppUtils.UtilAndroid
{
    /// <summary>
    /// Info android.
    /// </summary>
    public class InfoAndroid
    {
        /// <summary>
        /// Gets the get name model.
        /// </summary>
        /// <value>The get name model.</value>
        public static string GetNameModel
        {
            get
            {
                return Build.Brand + " " + Build.Model;
            }
        }
    }
}
