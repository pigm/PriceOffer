using System;
using Android.Bluetooth;

namespace liderofertas.AppUtils
{
    public class BluetoothConnect
    {
        public static bool IsConnected()
        {
            bool conectado = false;
            BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            if (bluetoothAdapter.IsEnabled)
                conectado = true;
            else
                conectado = false;

            return conectado; 
        }
    }
}
