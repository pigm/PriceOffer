using System;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Apps.Common.Utils.Utilitarios;
using liderofertas.AppUtils;

namespace liderofertas.AppPresenters.PresenterActivity
{
    public class DetalleProductoPasilloPresenter
    {
        /// <summary>
        /// Mostrars the producto detalle.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="imgProductoDetalle">Image producto detalle.</param>
        /// <param name="lblNombreProducto">Lbl nombre producto.</param>
        /// <param name="lblMarcaCategoria">Lbl marca categoria.</param>
        /// <param name="lblPrecioOferta">Lbl precio oferta.</param>
        public static void MostrarProductoDetalle(Activity activity, ImageView imgProductoDetalle, TextView lblNombreProducto, TextView lblMarcaCategoria, TextView lblPrecioOferta)
        {
            byte[] imageBytes = Convert.FromBase64String(AndroidDataManager.ProductoPasillo.imagen);
            imgProductoDetalle.SetImageBitmap(BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length));
            lblNombreProducto.Text = AndroidDataManager.ProductoPasillo.nombreproducto;
            lblMarcaCategoria.Text = AndroidDataManager.ProductoPasillo.marcaproducto;
            var preciooffer = String.Format("{0:N0}", AndroidDataManager.ProductoPasillo.preciooferta);
            lblPrecioOferta.Text = "$" + preciooffer.Replace(",",".");
        }

        /// <summary>
        /// Productos the detalle.
        /// </summary>
        /// <param name="llPanelConProducto">Ll panel con producto.</param>
        /// <param name="llPanelSinProducto">Ll panel sin producto.</param>
        /// <param name="activity">Activity.</param>
        /// <param name="imgProductoDetalle">Image producto detalle.</param>
        /// <param name="lblNombreProducto">Lbl nombre producto.</param>
        /// <param name="lblMarcaCategoria">Lbl marca categoria.</param>
        /// <param name="lblPrecioOferta">Lbl precio oferta.</param>
        public static void ProductoDetalle(LinearLayout llPanelConProducto, LinearLayout llPanelSinProducto, Activity activity, ImageView imgProductoDetalle, TextView lblNombreProducto, TextView lblMarcaCategoria, TextView lblPrecioOferta, LinearLayout sheet_suc)
        {
            if (AndroidDataManager.ProductoPasillo != null)
            {
                DetalleProductoPasilloPresenter.MostrarProductoDetalle(activity, imgProductoDetalle, lblNombreProducto, lblMarcaCategoria, lblPrecioOferta);
                llPanelConProducto.Visibility = ViewStates.Visible;
                llPanelSinProducto.Visibility = ViewStates.Gone;
                sheet_suc.Visibility = ViewStates.Visible;
            }
            else
            {
                llPanelConProducto.Visibility = ViewStates.Gone;
                llPanelSinProducto.Visibility = ViewStates.Visible;
                sheet_suc.Visibility = ViewStates.Gone;
            }
        }
    }
}
