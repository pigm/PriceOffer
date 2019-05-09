using System;
using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Widget;
using liderofertas.AppActivitys;
using liderofertas.AppUtils;

namespace liderofertas.AppPresenters.PresenterDialog
{
    /// <summary>
    /// Activar bluetooth presenter.
    /// </summary>
    public class ActivarBluetoothPresenter
    {
        /// <summary>
        /// Views the mensaje dialogo.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="customDialog">Custom dialog.</param>
        public static void ViewMensajeDialogo(Activity activity, Dialog customDialog)
        {
            customDialog = new Dialog(activity, Resource.Style.MyThemeTranslucent);          
            customDialog.SetCancelable(false);
            customDialog.SetContentView(Resource.Layout.dialog_activa_bluetooth);
            Button btnCancelarBluetooth = customDialog.FindViewById<Button>(Resource.Id.btnCancelarBluetooth);
            Button btnActivarBluetooth = customDialog.FindViewById<Button>(Resource.Id.btnActivarBluetooth);

            btnCancelarBluetooth.Click += delegate { customDialog.Dismiss(); };
            btnActivarBluetooth.Click += delegate { ActivarBluetoothPresenter.IrAHomeOfertas(activity); };
            customDialog.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            customDialog.Show();
        }

        /// <summary>
        /// Irs the AH ome ofertas.
        /// </summary>
        /// <param name="activity">Activity.</param>
        private static async void IrAHomeOfertas(Activity activity)
        {
            if (!BluetoothConnect.IsConnected()){
                BluetoothAdapter mBluetoothAdapter = BluetoothAdapter.DefaultAdapter;
                mBluetoothAdapter.Enable();
                Toast.MakeText(activity.ApplicationContext, "Bluetooth activado", ToastLength.Short).Show();
                activity.StartActivity(new Intent(activity, typeof(HomeOfertasActivity)));            
            }else
                activity.StartActivity(new Intent(activity, typeof(HomeOfertasActivity)));               
        }
    }
}