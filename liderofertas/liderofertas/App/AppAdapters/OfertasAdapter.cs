using System;
using System.Collections.Generic;
using System.Linq;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Apps.Common.Models.Modelo;
using Android.Content;
using Android.Text;
using System.IO;
using Android.Provider;
using liderofertas.AppUtils;
using Android.OS;

namespace liderofertas.AppAdapters
{
    public class OfertasAdapter : BaseAdapter
    {
        Context adapterContext;
        List<ProductosOfertasModelAndroid> dataOfertas;
        public OfertasAdapter(Context context, List<ProductosOfertasModelAndroid> dataOfertas)
        {
            this.adapterContext = context;
            this.dataOfertas = dataOfertas;
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public override int Count => dataOfertas.Count();

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <returns>The item.</returns>
        /// <param name="position">Position.</param>
        public override Java.Lang.Object GetItem(int position)
        {
            return 0;
        }


        /// <summary>
        /// Gets the item identifier.
        /// </summary>
        /// <returns>The item identifier.</returns>
        /// <param name="position">Position.</param>
        public override long GetItemId(int position)
        {
            return position;
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <returns>The view.</returns>
        /// <param name="position">Position.</param>
        /// <param name="convertView">Convert view.</param>
        /// <param name="parent">Parent.</param>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                LayoutInflater inflater = (LayoutInflater)adapterContext.GetSystemService(Context.LayoutInflaterService);
                convertView = inflater.Inflate(Resource.Layout.layout_producto_oferta, parent, false);
            }

            TextView nombreProducto = (TextView)convertView.FindViewById(Resource.Id.categoria_name);
            TextView marca_categoria = (TextView)convertView.FindViewById(Resource.Id.marca_categoria);
            TextView precioOferta = (TextView)convertView.FindViewById(Resource.Id.precio_oferta);
            TextView precioAntes = (TextView)convertView.FindViewById(Resource.Id.precio_antes);
            ImageView image = (ImageView)convertView.FindViewById(Resource.Id.image_categoria);
            nombreProducto.Text = dataOfertas[position].Nombre;
            marca_categoria.Text = dataOfertas[position].Marca + " - " + dataOfertas[position].Categoria;
            var priceoffer = String.Format("{0:N0}", dataOfertas[position].Preciooferta);
            var priceold = String.Format("{0:N0}", dataOfertas[position].Precioantes);
            precioOferta.Text = "$" + priceoffer.Replace(",",".");
            precioAntes.Text = "$" + priceold.Replace(",", ".");
            precioAntes.PaintFlags = precioAntes.PaintFlags | PaintFlags.StrikeThruText;
            image.SetImageBitmap(dataOfertas[position].Imagen);
            return convertView;
        }
    }
}
