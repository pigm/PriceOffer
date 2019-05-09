using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using liderofertas.AppActivitys;
using liderofertas.AppDialogs;
using liderofertas.AppUtils;

namespace liderofertas.AppPresenters.PresenterActivity
{
    /// <summary>
    /// Enrolamiento datos presenter.
    /// </summary>
    public class EnrolamientoDatosPresenter
    {
        /// <summary>
        /// Buttons the volver.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void BtnVolver(Activity activity){ activity.StartActivity(new Intent(activity, typeof(BienvenidaActivity))); }

        /// <summary>
        /// Buttons the continuar.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="txtEdad">Text edad.</param>
        public static void BtnContinuar(Activity activity, EditText txtEdad, int tipoDialogo)
        {
            if (!string.IsNullOrEmpty(txtEdad.Text))
                if (BluetoothConnect.IsConnected())
                    activity.StartActivity(new Intent(activity, typeof(HomeOfertasActivity)));
                else
                    ActivarBluetoothDialog.ViewDialogoActivarBluetooth(activity);
            else
                MensajeErrorDialog.ViewDialogoMensajeError(activity, ConstantesApp.MSJ_INFO_INCOMPLETA, false);
        }

        /// <summary>
        /// Gones the local.
        /// </summary>
        /// <param name="llDescripcionLocal">Ll descripcion local.</param>
        /// <param name="llBtnPlace">Ll button place.</param>
        public static void GoneLocal(LinearLayout llDescripcionLocal, LinearLayout llBtnPlace)
        {
            llDescripcionLocal.Visibility = ViewStates.Gone;
            llBtnPlace.Visibility = ViewStates.Gone;
        }

        /// <summary>
        /// Cargas the spinner.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="spiSexo">Spi sexo.</param>
        public static void CargaSpinner(Activity activity, Spinner spiSexo)
        {
            string[] Sexo = { "Ingresa tu sexo", "Masculino", "Femenino" };
            ArrayAdapter<String> adapterTipoSexo = new ArrayAdapter<String>(activity, Resource.Layout.textview_spinner, Sexo);
            adapterTipoSexo.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spiSexo.Adapter = adapterTipoSexo;
        }
    }
}
