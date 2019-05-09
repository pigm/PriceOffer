using System;
using System.Collections.Generic;
using System.Linq;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Apps.Common.Models.Modelo;
using Apps.Common.Utils.Utilitarios;
using liderofertas.AppAdapters;
using liderofertas.AppDialogs;
using liderofertas.AppUtils;

namespace liderofertas.AppFragments
{
    /// <summary>
    /// Fragment pasillos.
    /// </summary>
    public class FragmentPasillos : Fragment, ExpandableListView.IOnGroupClickListener, ExpandableListView.IOnChildClickListener
    {
        AdapterFilterExpandable adapterFilterExpandable;
        ExpandableListView eListView;
        FragmentManager SupportFragmentManager;
        LinearLayout llDescripcionLocal, llBtnPlace;
        RecyclerView listaDepartamentos;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:liderofertas.AppFragments.FragmentPasillos"/> class.
        /// </summary>
        /// <param name="sfm">Sfm.</param>
        public FragmentPasillos(FragmentManager sfm, LinearLayout llDescripcionLocal, LinearLayout llBtnPlace) { 
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
            ViewGroup v = (ViewGroup)inflater.Inflate(Resource.Layout.fragment_pasillos, container, false);
            listaDepartamentos = (RecyclerView)v.FindViewById(Resource.Id.listaDepartamentos);
            eListView = (ExpandableListView)v.FindViewById(Resource.Id.filter_expandablelist);
            llDescripcionLocal.Visibility = ViewStates.Gone;
            llBtnPlace.Visibility = ViewStates.Gone;   
            adapterFilterExpandable = new AdapterFilterExpandable(this.Activity, SupportFragmentManager);
            eListView.SetAdapter(adapterFilterExpandable);
            eListView.SetOnGroupClickListener(this);
            eListView.SetOnChildClickListener(this);
            var totalDeps = AndroidDataManager.Pasillos.Count;
            var totalCate = 0;
            foreach (PasilloModelAndroid cat in AndroidDataManager.Pasillos)
            {
                totalCate = totalCate + cat.subcategorias.Count;
            }
            var i = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 65 * (totalDeps + totalCate), this.Resources.DisplayMetrics);
            eListView.LayoutParameters.Height = i;
            eListView.RequestLayout();
            return v;
        }


        /// <summary>
        /// Ons the options item selected.
        /// </summary>
        /// <returns><c>true</c>, if options item selected was oned, <c>false</c> otherwise.</returns>
        /// <param name="item">Item.</param>
        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {

                Activity.OnBackPressed();
            }
            return base.OnOptionsItemSelected(item);
        }

        /// <summary>
        /// Ons the group click.
        /// </summary>
        /// <returns><c>true</c>, if group click was oned, <c>false</c> otherwise.</returns>
        /// <param name="parent">Parent.</param>
        /// <param name="clickedView">Clicked view.</param>
        /// <param name="groupPosition">Group position.</param>
        /// <param name="id">Identifier.</param>
        public bool OnGroupClick(ExpandableListView parent, View clickedView, int groupPosition, long id){ return false; }


        /// <summary>
        /// Sets the height of the list view.
        /// </summary>
        /// <param name="listView">List view.</param>
        /// <param name="group">Group.</param>
        private void setListViewHeight(ExpandableListView listView, int group)
        {
            AdapterFilterExpandable listAdapter = (AdapterFilterExpandable)listView.ExpandableListAdapter;
            int totalHeight = 0;
            int desiredWidth = View.MeasureSpec.MakeMeasureSpec(listView.Width, MeasureSpecMode.Exactly);
            for (int i = 0; i < listAdapter.GroupCount; i++)
            {
                View groupItem = listAdapter.GetGroupView(i, false, null, listView);
                groupItem.Measure(desiredWidth, (int)MeasureSpecMode.Unspecified);

                totalHeight += groupItem.MeasuredHeight;

                if (((listView.IsGroupExpanded(i)) && (i != group))
                    || ((!listView.IsGroupExpanded(i)) && (i == group)))
                {
                    for (int j = 0; j < listAdapter.GetChildrenCount(i); j++)
                    {

                        View listItem = listAdapter.GetChildView(i, j, false, null,
                                listView);
                        listItem.Measure(desiredWidth, (int)MeasureSpecMode.Unspecified);

                        totalHeight += listItem.MeasuredHeight;

                    }
                }
            }
            var mParams = listView.LayoutParameters;
            int height = totalHeight
                + (listView.DividerHeight * (listAdapter.GroupCount - 1));
            if (height < 10)
                height = 200;
            mParams.Height = height;
            listView.LayoutParameters = mParams;
            listView.RequestLayout();
        }


        /// <summary>
        /// Ons the child click.
        /// </summary>
        /// <returns><c>true</c>, if child click was oned, <c>false</c> otherwise.</returns>
        /// <param name="parent">Parent.</param>
        /// <param name="clickedView">Clicked view.</param>
        /// <param name="groupPosition">Group position.</param>
        /// <param name="childPosition">Child position.</param>
        /// <param name="id">Identifier.</param>
        public bool OnChildClick(ExpandableListView parent, View clickedView, int groupPosition, int childPosition, long id)
        {
            TextView titulo = (TextView)clickedView.FindViewById(Resource.Id.nombre_categoria);
            var pasillo = AndroidDataManager.Pasillos.OrderBy(x => x.nombrePasillo).ToList();
            var subcategoriaSeleccionada = pasillo[groupPosition].subcategorias[childPosition];
            AndroidDataManager.ProductosXsubcategoria = subcategoriaSeleccionada.productos;
            AndroidDataManager.SubCategoriaXsubcategoria = pasillo[groupPosition].subcategorias[childPosition];
            ProductosPasilloDialog.ViewDialogoProductosPasillo(Activity, false);
            return true;
        }
    }
}
