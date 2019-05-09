using System;
using Android.Content;
using Android.Locations;

namespace liderofertas.AppUtils
{
    public class LocationUtils
    {

        public static bool IsGPSProvider(Context context)
        {
            LocationManager lm = (LocationManager)context.GetSystemService(Context.LocationService);
            return lm.IsProviderEnabled(LocationManager.GpsProvider);
        }

        public static bool IsNetowrkProvider(Context context)
        {
            LocationManager lm = (LocationManager)context.GetSystemService(Context.LocationService);
            return lm.IsProviderEnabled(LocationManager.NetworkProvider);
        }

    }
}
