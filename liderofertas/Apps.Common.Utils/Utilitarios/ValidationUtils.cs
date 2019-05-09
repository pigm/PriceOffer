using System;
using Plugin.Connectivity;

namespace Apps.Common.Utils.Utilitarios
{
    /// <summary>
    /// Validation utils.
    /// </summary>
    public class ValidationUtils
    {
        /// <summary>
        /// Gets the network status.
        /// </summary>
        /// <returns><c>true</c>, if network status was gotten, <c>false</c> otherwise.</returns>
        public static bool GetNetworkStatus()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}
