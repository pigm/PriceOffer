using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Widget;
using Apps.Common.Models.Modelo;
using Apps.Common.Utils.Utilitarios;
using liderofertas.AppActivitys;
using liderofertas.AppAdapters;
using liderofertas.AppDialogs;
using liderofertas.AppUtils;

namespace liderofertas.AppPresenters.PresenterDialog
{
    /// <summary>
    /// Productos pasillo presenter.
    /// </summary>
    public class ProductosPasilloPresenter
    {
        /// <summary>
        /// Views the mensaje dialogo.
        /// </summary>
        /// <param name="activity">Activity.</param>
        /// <param name="customDialog">Custom dialog.</param>
        public static void ViewMensajeDialogo(Activity activity, Dialog customDialog, bool IsFromBeacons)
        {
            customDialog = new Dialog(activity, Resource.Style.ThemeDialogProductoPasillo);
            customDialog.SetCancelable(false);
            customDialog.SetContentView(Resource.Layout.dialog_productos_pasillo);
            GridView categoriasView = (GridView)customDialog.FindViewById(Resource.Id.gridViewProd);
            LinearLayout llBtnCerrarDialogo = customDialog.FindViewById<LinearLayout>(Resource.Id.llBtnCerrarDialogo);
            TextView lblTipoOfertaDesde = customDialog.FindViewById<TextView>(Resource.Id.lblTipoOfertaDesde);
            llBtnCerrarDialogo.Click += delegate { AndroidDataManager.CustomDialogViewOffer = null; ProductosPasilloPresenter.CloseThisDialog(activity, customDialog); };
            if (!IsFromBeacons)
            {
                lblTipoOfertaDesde.Text = AndroidDataManager.SubCategoriaXsubcategoria.nombresubcategoria;
                ProductosPasilloAdapter ofertasPasilloAdapter = new ProductosPasilloAdapter(activity, AndroidDataManager.SubCategoriaXsubcategoria.productos);
                categoriasView.Adapter = ofertasPasilloAdapter;
                categoriasView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
                {
                    AndroidDataManager.ProductoPasillo = AndroidDataManager.SubCategoriaXsubcategoria.productos[args.Position];
                    if (AndroidDataManager.ProductoPasillo != null)
                    {
                        activity.StartActivity(new Intent(activity, typeof(DetalleProductoPasilloActivity)));
                    }
                    else
                    {
                        MensajeErrorDialog.ViewDialogoMensajeError(activity, ConstantesApp.MSJ_ERROR_SIN_PRODUCTOS, true);
                    }
                };
            }
            else
            {
                PasilloModelAndroid pasillo = AndroidDataManager.Pasillos.Where(p => p.tag == AndroidDataManager.ContextProximity.Tag).FirstOrDefault();
                if (pasillo != null)
                {
                    lblTipoOfertaDesde.Text = pasillo.nombrePasillo;
                    if (AndroidDataManager.TotalProductosPasillo.Count == 0)
                    {
                        foreach (var subcategorias in pasillo.subcategorias)
                        {
                            foreach (var productos in subcategorias.productos)
                            {
                                AndroidDataManager.TotalProductosPasillo.Add(productos);
                            }
                        }
                    }

                    ProductosPasilloAdapter ofertasPasilloAdapter = new ProductosPasilloAdapter(activity, AndroidDataManager.TotalProductosPasillo);
                    categoriasView.Adapter = ofertasPasilloAdapter;
                    categoriasView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
                    {
                        AndroidDataManager.ProductoPasillo = AndroidDataManager.TotalProductosPasillo[args.Position];
                        if (AndroidDataManager.ProductoPasillo != null)
                        {
                            activity.StartActivity(new Intent(activity, typeof(DetalleProductoPasilloActivity)));
                        }
                        else
                        {
                            MensajeErrorDialog.ViewDialogoMensajeError(activity, ConstantesApp.MSJ_ERROR_SIN_PRODUCTOS, true);
                        }
                    };
                }
                else
                {
                    //mensaje no existe pasillo
                }
            }
            AndroidDataManager.CustomDialogProductosPasillo = customDialog;
            customDialog.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);            
            customDialog.Show();
            GC.Collect();
        }

        /// <summary>
        /// Closes the this dialog.
        /// </summary>
        /// <param name="customDialog">Custom dialog.</param>
        private static void CloseThisDialog(Activity activity, Dialog customDialog)
        {
            customDialog.Dismiss();
            AndroidDataManager.CustomDialogProductosPasillo = null;
            AndroidDataManager.TotalProductosPasillo.Clear();
            AndroidDataManager.ProductosXsubcategoria = null;
            AndroidDataManager.SubCategoriaXsubcategoria = null;
        }
    }
}