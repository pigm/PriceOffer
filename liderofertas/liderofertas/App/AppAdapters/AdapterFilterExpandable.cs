using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Apps.Common.Models.Modelo;
using Apps.Common.Utils.Utilitarios;
using liderofertas.AppUtils;

namespace liderofertas.AppAdapters
{
    public class AdapterFilterExpandable : BaseExpandableListAdapter
    {
        List<PasilloModelAndroid> listGroup;
        Context context = null;
        FragmentManager fragmentManager;
        CultureInfo culture;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WalmartScanCL_Android.Adapters.AdapterFilterExpandable"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="fragmentManager">Fragment manager.</param>
        public AdapterFilterExpandable(Android.App.Activity context, FragmentManager fragmentManager) //, FragmentManager fragmentManage
        {
            this.listGroup = AndroidDataManager.Pasillos.OrderBy(x => x.nombrePasillo).ToList();
            this.context = context;
            this.fragmentManager = fragmentManager;
            culture = new CultureInfo("es-CL");

        }

        /// <summary>
        /// Gets the group count.
        /// </summary>
        /// <value>The group count.</value>
        public override int GroupCount
        {
            get
            {
                return listGroup.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:WalmartScanCL_Android.Adapters.AdapterFilterExpandable"/>
        /// has stable identifiers.
        /// </summary>
        /// <value><c>true</c> if has stable identifiers; otherwise, <c>false</c>.</value>
        public override bool HasStableIds
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the child.
        /// </summary>
        /// <returns>The child.</returns>
        /// <param name="groupPosition">Group position.</param>
        /// <param name="childPosition">Child position.</param>
        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            return null;
        }

        /// <summary>
        /// Gets the child identifier.
        /// </summary>
        /// <returns>The child identifier.</returns>
        /// <param name="groupPosition">Group position.</param>
        /// <param name="childPosition">Child position.</param>
        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        /// <summary>
        /// Gets the children count.
        /// </summary>
        /// <returns>The children count.</returns>
        /// <param name="groupPosition">Group position.</param>
        public override int GetChildrenCount(int groupPosition)
        {
            return listGroup[groupPosition].subcategorias.Count;
        }


        /// <summary>
        /// Gets the child view.
        /// </summary>
        /// <returns>The child view.</returns>
        /// <param name="groupPosition">Group position.</param>
        /// <param name="childPosition">Child position.</param>
        /// <param name="isLastChild">If set to <c>true</c> is last child.</param>
        /// <param name="convertView">Convert view.</param>
        /// <param name="parent">Parent.</param>
        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            if (convertView == null){
                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                convertView = inflater.Inflate(Resource.Layout.row_subcategoria, null);
            }
            TextView nombre = (TextView)convertView.FindViewById(Resource.Id.lblNombreSubcategoriaRow);
            nombre.SetTextColor(Android.Graphics.Color.Rgb(44,44,44));
            nombre.Text = listGroup[groupPosition].subcategorias[childPosition].nombresubcategoria;
            return convertView;
        }

        /// <summary>
        /// Gets the group.
        /// </summary>
        /// <returns>The group.</returns>
        /// <param name="groupPosition">Group position.</param>
        public override Java.Lang.Object GetGroup(int groupPosition){ return null; }

        /// <summary>
        /// Gets the group identifier.
        /// </summary>
        /// <returns>The group identifier.</returns>
        /// <param name="groupPosition">Group position.</param>
        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        /// <summary>
        /// Gets the group view.
        /// </summary>
        /// <returns>The group view.</returns>
        /// <param name="groupPosition">Group position.</param>
        /// <param name="isExpanded">If set to <c>true</c> is expanded.</param>
        /// <param name="convertView">Convert view.</param>
        /// <param name="parent">Parent.</param>
        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                convertView = inflater.Inflate(Resource.Layout.row_categoria, null);
            }
            TextView titulo = (TextView)convertView.FindViewById(Resource.Id.nombre_categoria);
            ImageView image_producto = convertView.FindViewById<ImageView>(Resource.Id.image_producto);
            titulo.Text = listGroup[groupPosition].nombrePasillo;
            titulo.SetTextColor(Android.Graphics.Color.Rgb(44, 44, 44));
            image_producto.SetImageBitmap(listGroup[groupPosition].imagenPasillo);
            return convertView;


        }

        /// <summary>
        /// Ises the child selectable.
        /// </summary>
        /// <returns><c>true</c>, if child selectable was ised, <c>false</c> otherwise.</returns>
        /// <param name="groupPosition">Group position.</param>
        /// <param name="childPosition">Child position.</param>
        public override bool IsChildSelectable(int groupPosition, int childPosition){ return true; }

        /// <summary>
        /// Java object wrapper.
        /// </summary>
        public class JavaObjectWrapper<T> : Java.Lang.Object{ public T Obj { get; set; } }
    }
}
