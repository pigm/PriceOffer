using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using liderofertas.AppUtils;

namespace liderofertas.AppAdapters
{
    public class ProductosPasilloAdapter : BaseAdapter
    {
        Context adapterContext;
        List<ProductoModelAndroid> dataProductoPasillo;
        public ProductosPasilloAdapter(Context context, List<ProductoModelAndroid> dataProductoPasillo)
        {
            this.adapterContext = context;
            this.dataProductoPasillo = dataProductoPasillo;
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public override int Count => dataProductoPasillo.Count();

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
            nombreProducto.Text = dataProductoPasillo[position].nombreproducto;
            marca_categoria.Text = dataProductoPasillo[position].marcaproducto;
            var priceofferpas = String.Format("{0:N0}", dataProductoPasillo[position].preciooferta);
            var priceoldpas = String.Format("{0:N0}", dataProductoPasillo[position].precioantes);
            precioOferta.Text = "$" + priceofferpas.Replace(",",".");
            precioAntes.Text = "$" + priceoldpas.Replace(",", ".");
            precioAntes.PaintFlags = precioAntes.PaintFlags | PaintFlags.StrikeThruText;
            byte[] imageBytes = Convert.FromBase64String(dataProductoPasillo[position].imagen);
            Bitmap newImg = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
            var streamImg = new MemoryStream();
            newImg.Compress(Bitmap.CompressFormat.Jpeg, 15, streamImg);
            image.SetImageBitmap(newImg);
            return convertView;
        }
    }
}
