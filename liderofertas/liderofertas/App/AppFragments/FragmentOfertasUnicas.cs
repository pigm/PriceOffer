using System;
using System.IO;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Apps.Common.Utils.Utilitarios;

namespace liderofertas.AppFragments
{
    /// <summary>
    /// Fragment ofertas unicas.
    /// </summary>
    public class FragmentOfertasUnicas : Fragment
    {
        Bitmap image;
        FragmentManager SupportFragmentManager;
        ImageView imagenes_ofertaunica;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:liderofertas.AppFragments.FragmentOfertasUnicas"/> class.
        /// </summary>
        /// <param name="sfm">Sfm.</param>
        /// <param name="position">Position.</param>
        public FragmentOfertasUnicas(FragmentManager sfm, Bitmap image)
        {
            SupportFragmentManager = sfm;
            ///this.position = position;
            this.image = image;
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
            ViewGroup v = (ViewGroup)inflater.Inflate(Resource.Layout.layout_oferta_unica, container, false);
            imagenes_ofertaunica = (ImageView)v.FindViewById(Resource.Id.imagenes_ofertaunica);          
            imagenes_ofertaunica.SetImageBitmap(image);
            return v;
        }
    }
}
