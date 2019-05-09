using System;
namespace liderofertas.AppUtils
{
    /// <summary>
    /// Mascaras edit text.
    /// </summary>
    public class MascarasEditText
    {
        /// <summary>
        /// Formatears the monto.
        /// </summary>
        /// <returns>The monto.</returns>
        /// <param name="monto">Monto.</param>
        public static string FormatearMonto(string monto){
            string montoPeso;
            if (monto == null || monto.Equals(""))
                montoPeso = string.Empty;
            else{
                monto = LimpiarMontoPesos(monto);    
                long num = Convert.ToInt64(monto);
                monto = String.Format("{0:N0}", num);
                montoPeso = monto.Replace(",", ".");
            }
            return montoPeso;
        }

        /// <summary>
        /// Limpiars the monto pesos.
        /// </summary>
        /// <returns>The monto pesos.</returns>
        /// <param name="monto">Monto.</param>
        public static string LimpiarMontoPesos(string monto){
            monto = monto.Replace(".", "");
            return monto;
        }

        /// <summary>
        /// Formatears the rut.
        /// </summary>
        /// <returns>The rut.</returns>
        /// <param name="rut">Rut.</param>
        public static string FormatearRut(string rut){
            if (rut.Length > 3)
                rut = ObtenerRutFormateado(rut);
            else
                rut = LimpiaRut(rut);
       
            return rut;
        }

        /// <summary>
        /// Obteners the rut formateado.
        /// </summary>
        /// <returns>The rut formateado.</returns>
        /// <param name="rut">Rut.</param>
        public static string ObtenerRutFormateado(string rut){
            int cont = 0;
            string format;
            if (rut.Length == 0)
                return "";
            else{
                rut = LimpiaRut(rut);
                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--){
                    format = rut.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0){
                        format = "." + format;
                        cont = 0;
                    }
                }
                return format;
            }
        }

        /// <summary>
        /// Limpias the rut.
        /// </summary>
        /// <returns>The rut.</returns>
        /// <param name="_rut">Rut.</param>
        /// <param name="range">Range.</param>
        public static string LimpiaRut(string _rut, int range = 0){
            _rut = _rut.Replace(".", "").Replace("-", "");
            if (range == 1)
                _rut = _rut.Remove(_rut.Length - 1);

            return _rut;
        }
    }
}
