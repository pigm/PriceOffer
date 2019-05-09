using System;
using System.Collections.Generic;
using System.IO;
using Android.Content;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Apps.Common.Models.Modelo;
using Apps.Common.Utils.Utilitarios;
using liderofertas.AppActivitys;
using liderofertas.AppFragments;
using liderofertas.AppUtils;

namespace liderofertas.AppAdapters
{
    public class AdapterProductoRelacionadoPasillo : RecyclerView.Adapter
    {
        List<ProductoModelAndroid> list;
        List<ProductoModelAndroid> originList;
        List<object> productoDesdeRecicler;
        public event EventHandler<List<Object>> itemClick;

        FragmentDetalleProductoPasillo fragment;

        public AdapterProductoRelacionadoPasillo(List<ProductoModelAndroid> lista, FragmentDetalleProductoPasillo fragment)
        {
            list = lista;
            originList = lista;
            this.fragment = fragment;
        }

        /// <summary>
        /// Gets the item count.
        /// </summary>
        /// <value>The item count.</value>
        public override int ItemCount
        {
            get
            {
                return list.Count;
            }
        }

        /// <summary>
        /// Sucursal view holder.
        /// </summary>
        public class ProductoRelacionadoPasilloViewHolder : RecyclerView.ViewHolder
        {

            public View mView;
            public TextView mNombre { get; private set; }
            public TextView mMarcaCategoria { get; private set; }
            public TextView mPrecioAntes { get; private set; }
            public TextView mPrecioOferta { get; private set; }
            public ImageView mImage { get; set; }
            public LinearLayout row { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:RikiiRecetas.Adapter.AdapterPais.PaisViewHolder"/> class.
            /// </summary>
            /// <param name="view">View.</param>
            /// <param name="listener">Listener.</param>
            public ProductoRelacionadoPasilloViewHolder(View view, Action<List<Object>> listener) : base(view)
            {
                mImage = view.FindViewById<ImageView>(Resource.Id.image_producto);
                mNombre = view.FindViewById<TextView>(Resource.Id.nombre_producto);
                mMarcaCategoria = view.FindViewById<TextView>(Resource.Id.marca_categoria);
                //mPrecioAntes  = view.FindViewById<ImageView>(Resource.Id.image_producto_relacionado);
                //mPrecioOferta = view.FindViewById<ImageView>(Resource.Id.image_producto_relacionado);
                row = view.FindViewById<LinearLayout>(Resource.Id.fila_producto);
            }
        }

        /// <summary>
        /// Ons the bind view holder.
        /// </summary>
        /// <param name="holder">Holder.</param>
        /// <param name="position">Position.</param>
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ProductoRelacionadoPasilloViewHolder miholder = holder as ProductoRelacionadoPasilloViewHolder;
            LinearLayout view = miholder.row;
            ProductoModelAndroid productoRelacionadoPasillo = list[position];
            byte[] imageBytes = Convert.FromBase64String(productoRelacionadoPasillo.imagen);
            Bitmap newImg = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
            var streamImg = new MemoryStream();
            newImg.Compress(Bitmap.CompressFormat.Jpeg, 15, streamImg);
            miholder.mImage.SetImageBitmap(newImg);
            miholder.mNombre.Text = productoRelacionadoPasillo.nombreproducto;
            miholder.mMarcaCategoria.Text = productoRelacionadoPasillo.marcaproducto;
            //miholder.mPrecioOferta.Text = "$"+productoRelacionado.Preciooferta;
            //miholder.mPrecioAntes.Text = "$" + productoRelacionado.Precioantes;
        }

        /// <summary>
        /// Ons the create view holder.
        /// </summary>
        /// <returns>The create view holder.</returns>
        /// <param name="parent">Parent.</param>
        /// <param name="viewType">View type.</param>
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View card = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row_producto_relacionado, parent, false);
            ProductoRelacionadoPasilloViewHolder viewholder = new ProductoRelacionadoPasilloViewHolder(card, onClick);

            viewholder.row.Click += (sender, e) =>
            {
                ProductoModelAndroid productoPasilloRelacionado = list[viewholder.AdapterPosition];
                productoDesdeRecicler = new List<object>();
                productoDesdeRecicler.Add(productoPasilloRelacionado.idproducto);
                productoDesdeRecicler.Add(productoPasilloRelacionado.nombreproducto);
                productoDesdeRecicler.Add(productoPasilloRelacionado.marcaproducto);
                productoDesdeRecicler.Add(productoPasilloRelacionado.precioantes);
                productoDesdeRecicler.Add(productoPasilloRelacionado.preciooferta);
                productoDesdeRecicler.Add(productoPasilloRelacionado.imagen);
                this.fragment.Activity.FinishActivity(100);
                AndroidDataManager.ProductoPasillo = productoPasilloRelacionado;
                itemClick(sender, productoDesdeRecicler);
            };
            return viewholder;
        }

        /// <summary>
        /// Ons the click.
        /// </summary>
        /// <param name="locationName">Location name.</param>
        void onClick(List<Object> locationName)
        {
            fragment.Activity.StartActivity(new Intent(fragment.Activity, typeof(DetalleProductoPasilloActivity)));
        }
    }
}
