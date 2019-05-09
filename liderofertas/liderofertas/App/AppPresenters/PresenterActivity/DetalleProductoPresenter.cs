using System;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Apps.Common.Utils.Utilitarios;
using liderofertas.AppUtils;

namespace liderofertas.AppPresenters.PresenterActivity
{
    /// <summary>
    /// Detalle producto presenter.
    /// </summary>
    public class DetalleProductoPresenter
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

            imgProductoDetalle.SetImageBitmap(AndroidDataManager.ProductoOferta.Imagen);
            lblNombreProducto.Text = AndroidDataManager.ProductoOferta.Nombre;
            lblMarcaCategoria.Text = AndroidDataManager.ProductoOferta.Marca + " - " + AndroidDataManager.ProductoOferta.Categoria;
            var priceoferta = String.Format("{0:N0}", AndroidDataManager.ProductoOferta.Preciooferta);
            lblPrecioOferta.Text = "$" + priceoferta.Replace(",",".");
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
            if (AndroidDataManager.ProductoOferta != null)
            {
                DetalleProductoPresenter.MostrarProductoDetalle(activity, imgProductoDetalle, lblNombreProducto, lblMarcaCategoria, lblPrecioOferta);
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
