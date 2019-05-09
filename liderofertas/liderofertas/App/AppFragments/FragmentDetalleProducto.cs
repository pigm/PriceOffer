using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Apps.Common.Models.Modelo;
using Apps.Common.Utils.Utilitarios;
using liderofertas.AppActivitys;
using liderofertas.AppAdapters;
using liderofertas.AppPresenters.PresenterActivity;
using liderofertas.AppUtils;

namespace liderofertas.AppFragments
{
    /// <summary>
    /// Fragment detalle producto.
    /// </summary>
    public class FragmentDetalleProducto : Android.Support.V4.App.Fragment
    {
        AdapterProductoRelacionado adapter;
        BottomSheetBehavior bottomSheetBehavior_suc;
        float scale;
        FragmentManager fm;
        LinearLayout sheet_suc;
        ImageView imgProductoDetalle;
        LinearLayout llPanelConProducto, llPanelSinProducto, llBtnClose, toolbarDetalleProducto;
        LinearLayoutManager layoutManager;
        RecyclerView recycler;
        TextView lblNombreProducto, lblMarcaCategoria, lblPrecioOferta;
        ViewGroup v;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:liderofertas.AppFragments.FragmentDetalleProducto"/> class.
        /// </summary>
        /// <param name="fm">Fm.</param>
        public FragmentDetalleProducto(FragmentManager fm){ this.fm = fm; }

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        public override void OnCreate(Bundle savedInstanceState){ base.OnCreate(savedInstanceState);}

        /// <summary>
        /// Ons the create view.
        /// </summary>
        /// <returns>The create view.</returns>
        /// <param name="inflater">Inflater.</param>
        /// <param name="container">Container.</param>
        /// <param name="savedInstanceState">Saved instance state.</param>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            scale = Context.Resources.DisplayMetrics.Density;
            int pixels = 0;
            if (v == null)
            {
                v = (ViewGroup)inflater.Inflate(Resource.Layout.fragment_detalle_producto, container, false);
            }

            imgProductoDetalle = v.FindViewById<ImageView>(Resource.Id.imgProductoDetalle);
            llBtnClose = v.FindViewById<LinearLayout>(Resource.Id.llBtnClose);
            llPanelConProducto = v.FindViewById<LinearLayout>(Resource.Id.llPanelConProducto);
            llPanelSinProducto = v.FindViewById<LinearLayout>(Resource.Id.llPanelSinProducto);
            lblNombreProducto = v.FindViewById<TextView>(Resource.Id.lblNombreProducto);
            lblMarcaCategoria = v.FindViewById<TextView>(Resource.Id.lblMarcaCategoria);
            lblPrecioOferta = v.FindViewById<TextView>(Resource.Id.lblPrecioOferta);
            sheet_suc = v.FindViewById<LinearLayout>(Resource.Id.linear_sheet_sucursales);
            recycler = v.FindViewById<RecyclerView>(Resource.Id.mi_recycler_view_prelacionado);
            toolbarDetalleProducto = v.FindViewById<LinearLayout>(Resource.Id.toolbarDetalleProducto);

            llBtnClose.Click += delegate { Activity.Finish(); Activity.StartActivity(new Intent(Activity, typeof(HomeOfertasActivity))); };      
            DetalleProductoPresenter.ProductoDetalle(llPanelConProducto, llPanelSinProducto, Activity, imgProductoDetalle, lblNombreProducto, lblMarcaCategoria, lblPrecioOferta, sheet_suc);
            List<ProductosOfertasModelAndroid> filtroProductosCategoria = AndroidDataManager.ProductosOfertas.Where(x => x.Departamento == AndroidDataManager.ProductoOferta.Departamento).ToList();
            CoordinatorLayout.LayoutParams linearLayoutParams = new CoordinatorLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
            pixels = (int)(220 * scale + 0.5f);
            bottomSheetBehavior_suc = BottomSheetBehavior.From(sheet_suc);
            bottomSheetBehavior_suc.PeekHeight = pixels;
            linearLayoutParams.SetMargins(0, 0, 0, pixels);
            //toolbarDetalleProducto.LayoutParameters = linearLayoutParams;
            adapter = new AdapterProductoRelacionado(filtroProductosCategoria, this);
            adapter.itemClick += OnItemClick;
            recycler.SetAdapter(adapter);
            layoutManager = new LinearLayoutManager(Activity);
            recycler.SetLayoutManager(layoutManager);
            return v;
        }

        /// <summary>
        /// Ons the item click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void OnItemClick(object sender, List<Object> e){ StartActivity(new Intent(Activity, typeof(DetalleProductoActivity))); }
    }
}