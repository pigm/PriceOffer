using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Util;
using Android.Widget;
using Apps.Common.Utils.Utilitarios;
using liderofertas.AppActivitys;
using liderofertas.AppDialogs;
using liderofertas.AppUtils;

namespace liderofertas.AppPresenters.PresenterActivity
{
    /// <summary>
    /// Bienvenida presenter.
    /// </summary>
    public class BienvenidaPresenter
    {
        /// <summary>
        /// Ingresos the rut.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="txtRut">Text rut.</param>
        public static void IngresoRut(Activity activity, EditText txtRut, int tipoDialogo)
        {
            if (!string.IsNullOrEmpty(txtRut.Text) && BienvenidaPresenter.ValidarRut(txtRut.Text))
            {
                try
                {
                    LoadingDialog.ViewDialogoLoadingAsync(activity);
                    Task startupwork = new Task(() => { Task.Delay(4000).Wait(); });
                    startupwork.ContinueWith(t => {
                        DataManager.IsAnonimo = false;
                        if (BluetoothConnect.IsConnected()) { 
                            activity.StartActivity(new Intent(activity, typeof(HomeOfertasActivity)));                      
                        }
                        else
                            ActivarBluetoothDialog.ViewDialogoActivarBluetooth(activity);
                    },
                     TaskScheduler.FromCurrentSynchronizationContext());
                    startupwork.Start();
                }
                catch (Exception ex) 
                {
                    Log.Info("ingreso con rut: ", ex.Message);
                }

            }
            else           
                MensajeErrorDialog.ViewDialogoMensajeError(activity, ConstantesApp.MSJ_RUT_INVALIDO, false);
        }

        /// <summary>
        /// Masks the rut.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="txtRut">Text rut.</param>
        public static void MaskRut(Activity activity, EditText txtRut)
        {
            txtRut.AddTextChangedListener(new MascarasTextWatcher(txtRut, activity, MascarasTextWatcher.TIPO_RUT));
        }

        /// <summary>
        /// Ingresos the anonimo.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public static void IngresoAnonimo(Activity activity)
        {
            DataManager.IsAnonimo = true;
            activity.StartActivity(new Intent(activity, typeof(EnrolamientoDatosActivity)));
        }

        public static void TextColorRutValid(Activity activity, EditText txtRut)
        {
            if (ValidarRut(txtRut.Text))
                txtRut.SetTextColor(Android.Support.V4.Content.ContextCompat.GetColorStateList(activity, Resource.Color.colorVerde));
            else
                txtRut.SetTextColor(Android.Support.V4.Content.ContextCompat.GetColorStateList(activity, Resource.Color.colorNegro));
        }

        /// <summary>
        /// Validars the rut.
        /// </summary>
        /// <returns><c>true</c>, if rut was validared, <c>false</c> otherwise.</returns>
        /// <param name="rut">Rut.</param>
        private static bool ValidarRut(string rut)
        {
            bool validacion = false;
            try{
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));
                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));
                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10){
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75)){
                    validacion = true;
                }
                if (dv == (char)(s != 0 ? s + 47 : 107)){
                    validacion = true;
                }
            }catch (Exception){
                validacion = false;
            }
            return validacion;
        }

    }
}
