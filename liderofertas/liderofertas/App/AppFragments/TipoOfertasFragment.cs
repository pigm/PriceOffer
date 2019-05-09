using System;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using liderofertas.AppAdapters;
using liderofertas.AppUtils;

namespace liderofertas.AppFragments
{
    /// <summary>
    /// Tipo ofertas fragment.
    /// </summary>
    public class TipoOfertasFragment : Fragment, TabLayout.IOnTabSelectedListener
    {
        FragmentManager SupportFragmentManager;
        LinearLayout llDescripcionLocal, llBtnPlace;
        TabLayout mTopNavigation;
        ViewPager viewPager;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:liderofertas.AppFragments.TipoOfertasFragment"/> class.
        /// </summary>
        /// <param name="sfm">Sfm.</param>
        public TipoOfertasFragment(FragmentManager sfm, LinearLayout llDescripcionLocal, LinearLayout llBtnPlace)
        {
            this.SupportFragmentManager = sfm;
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
            RetainInstance = true;
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
            ViewGroup v = (ViewGroup)inflater.Inflate(Resource.Layout.fragment_tipo_ofertas, container, false);
            return v;
        }

        /// <summary>
        /// Ons the view created.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="savedInstanceState">Saved instance state.</param>
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            viewPager = (ViewPager)view.FindViewById(Resource.Id.viewPager);
            setupViewPager(viewPager);
            mTopNavigation = (TabLayout)view.FindViewById(Resource.Id.tabsFrg);
            mTopNavigation.SetTabTextColors(Resources.GetColor(Resource.Color.colorGris), Resources.GetColor(Resource.Color.colorTabSelected));
            mTopNavigation.SetupWithViewPager(viewPager);
        }

        /// <summary>
        /// Setups the view pager.
        /// </summary>
        /// <param name="viewPager">View pager.</param>
        public void setupViewPager(ViewPager viewPager)
        {
            GenericFragmentPagerAdapter adapter = new GenericFragmentPagerAdapter(SupportFragmentManager);
            var dynamic = new FragmentOfertas(SupportFragmentManager, llDescripcionLocal, llBtnPlace);
            var dynamic2 = new FragmentPasillos(SupportFragmentManager, llDescripcionLocal, llBtnPlace);
            adapter.addFragment(dynamic, "Ofertas");
            adapter.addFragment(dynamic2, "Pasillos");
            viewPager.Adapter = adapter;
        }

        /// <summary>
        /// Ons the tab reselected.
        /// </summary>
        /// <param name="tab">Tab.</param>
        public void OnTabReselected(TabLayout.Tab tab){ GC.Collect(); }

        /// <summary>
        /// Ons the tab selected.
        /// </summary>
        /// <param name="tab">Tab.</param>
        public void OnTabSelected(TabLayout.Tab tab)
        {
            var pos = tab.Position;
        }

        /// <summary>
        /// Ons the tab unselected.
        /// </summary>
        /// <param name="tab">Tab.</param>
        public void OnTabUnselected(TabLayout.Tab tab){}
    }
}