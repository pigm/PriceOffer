using System;
using System.Collections.Generic;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Apps.Common.Models.Modelo;
using Apps.Common.Utils.Utilitarios;
using liderofertas.AppActivitys;
using liderofertas.AppAdapters;
using liderofertas.AppDialogs;
using liderofertas.AppPresenters.PresenterActivity;
using liderofertas.AppUtils;

namespace liderofertas.AppFragments
{
    public class FragmentOfertas : Fragment
    {
        AlphaAnimation buttonAnimation = new AlphaAnimation(1F, 0.4F);
        EditText txtTituloProductosDestacados;
        FragmentManager SupportFragmentManager;
        GridView categoriasView;
        LinearLayout linearLayoutCat, dynamicFragmentLinearLayout, llDescripcionLocal, llBtnPlace, llBtnSearch;
        List<ProductosOfertasModelAndroid> productoOfertas;
        TabLayout mTopNavigationOfertasUnicas;
        TextView lblTituloProductosDestacados;
        ViewPager viewPagerOfertasUnicas;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:liderofertas.AppFragments.FragmentOfertas"/> class.
        /// </summary>
        /// <param name="sfm">Sfm.</param>
        /// <param name="productoOfertas">Producto ofertas.</param>
        public FragmentOfertas(FragmentManager sfm, LinearLayout llDescripcionLocal, LinearLayout llBtnPlace)
        {
            this.SupportFragmentManager = sfm;
            this.productoOfertas = AndroidDataManager.ProductosOfertas;
            this.llDescripcionLocal = llDescripcionLocal;
            this.llBtnPlace = llBtnPlace;
        }

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        /// <summary>
        /// Ons the create view.
        /// </summary>
        /// <returns>The create view.</returns>
        /// <param name="inflater">Inflater.</param>
        /// <param name="container">Container.</param>
        /// <param name="savedInstanceState">Saved instance state.</param>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ViewGroup v = (ViewGroup)inflater.Inflate(Resource.Layout.fragment_ofertas, container, false);
            txtTituloProductosDestacados = (EditText)v.FindViewById(Resource.Id.txtTituloProductosDestacados);
            categoriasView = (GridView)v.FindViewById(Resource.Id.gridViewCat);
            llBtnSearch = (LinearLayout)v.FindViewById(Resource.Id.llBtnSearch);
            dynamicFragmentLinearLayout = (LinearLayout)v.FindViewById(Resource.Id.dynamicFragmentLinearLayout);
            linearLayoutCat = (LinearLayout)v.FindViewById(Resource.Id.linearLayoutCat);
            mTopNavigationOfertasUnicas = (TabLayout)v.FindViewById(Resource.Id.tabsFrgSub);
            lblTituloProductosDestacados = (TextView)v.FindViewById(Resource.Id.lblTituloProductosDestacados);
            viewPagerOfertasUnicas = (ViewPager)v.FindViewById(Resource.Id.viewPagerSub);
            llDescripcionLocal.Visibility = ViewStates.Gone;
            llBtnPlace.Visibility = ViewStates.Gone;
            llBtnSearch.Click += delegate { ClickBtnSearch(txtTituloProductosDestacados, lblTituloProductosDestacados); };
            HomeOfertasPresenter.SetupViewPagerOfertasUnicas(viewPagerOfertasUnicas, SupportFragmentManager);
            mTopNavigationOfertasUnicas.SetupWithViewPager(viewPagerOfertasUnicas);
            if (productoOfertas != null)
            {
                OfertasAdapter ofertasAdapter = new OfertasAdapter(this.Activity, productoOfertas);
                //ofertasAdapter.NotifyDataSetChanged(); -->refresh adapter...
                categoriasView.Adapter = ofertasAdapter;

                categoriasView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
                    Toast.MakeText(Activity.ApplicationContext, "Producto " + productoOfertas[args.Position].Nombre + ", " + productoOfertas[args.Position].Marca, ToastLength.Short).Show();
                    AndroidDataManager.ProductoOferta = productoOfertas[args.Position];
                    if (AndroidDataManager.ProductoOferta != null)
                    {
                        StartActivity(new Intent(Activity, typeof(DetalleProductoActivity)));
                    }
                    else
                    {
                        MensajeErrorDialog.ViewDialogoMensajeError(Activity, ConstantesApp.MSJ_ERROR_SIN_PRODUCTOS, true);
                    }
                };
            }
            else
            {
                StartActivity(new Intent(Activity, typeof(BienvenidaActivity)));
                Toast.MakeText(Activity.ApplicationContext, ConstantesApp.MSJ_ERROR_INESPERADO, ToastLength.Long).Show();
            }
            return v;
        }

        public void ClickBtnSearch(EditText txtTituloProductosDestacados, TextView lblTituloProductosDestacados)
        {
            lblTituloProductosDestacados.Visibility = ViewStates.Gone;
            txtTituloProductosDestacados.Visibility = ViewStates.Visible;
        }
    }
}
