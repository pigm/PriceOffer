using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Apps.Common.Models.Modelo;
using Apps.Common.Services.Delegate;
using Apps.Common.Utils.Utilitarios;
using liderofertas.AppAdapters;
using liderofertas.AppFragments;
using liderofertas.AppUtils;

namespace liderofertas.AppPresenters.PresenterActivity
{
    /// <summary>
    /// Home ofertas presenter.
    /// </summary>
    public class HomeOfertasPresenter
    {
        /// <summary>
        /// Inflates the fragment.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        /// <param name="SupportFragmentManager">Support fragment manager.</param>
        /// <param name="home">Home.</param>
        public static void InflateFragment(FragmentManager SupportFragmentManager, string home, LinearLayout llDescripcionLocal, LinearLayout llBtnPlace)
        {
            var ft = SupportFragmentManager.BeginTransaction();
            ft.Add(Resource.Id.defaultFrame, new TipoOfertasFragment(SupportFragmentManager, llDescripcionLocal, llBtnPlace), home);
            ft.Commit();
        }

        /// <summary>
        /// Enableses the action bar user.
        /// </summary>
        /// <param name="llBtnUser">Ll button user.</param>
        public static void EnablesActionBarUser(LinearLayout llBtnUser) 
        {
            if (DataManager.IsAnonimo)
                llBtnUser.Visibility = ViewStates.Gone;
            else
                llBtnUser.Visibility = ViewStates.Visible;
        }

        /// <summary>
        /// Setups the view pager ofertas unicas.
        /// </summary>
        /// <param name="viewPager">View pager.</param>
        public static void SetupViewPagerOfertasUnicas(ViewPager viewPager, FragmentManager SupportFragmentManager)
        {
            GenericFragmentPagerAdapter adapter = new GenericFragmentPagerAdapter(SupportFragmentManager);
            foreach (var item in AndroidDataManager.ProductosOfertasUnicas)
            {
                var ftOfertasUnicas = new FragmentOfertasUnicas(SupportFragmentManager, item.Imagen);
                adapter.addFragment(ftOfertasUnicas, "");
            }     
                              
            viewPager.Adapter = adapter;
        }

       
    }
}