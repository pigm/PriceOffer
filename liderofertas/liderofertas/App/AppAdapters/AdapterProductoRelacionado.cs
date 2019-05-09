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
    public class AdapterProductoRelacionado : RecyclerView.Adapter
    {
        List<ProductosOfertasModelAndroid> list;
        List<ProductosOfertasModelAndroid> originList;
        List<object> productoDesdeRecicler;
        public event EventHandler<List<Object>> itemClick;

        FragmentDetalleProducto fragment;

        public AdapterProductoRelacionado(List<ProductosOfertasModelAndroid> lista, FragmentDetalleProducto fragment)
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
        public class ProductoRelacionadoViewHolder : RecyclerView.ViewHolder
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
            public ProductoRelacionadoViewHolder(View view, Action<List<Object>> listener) : base(view)
            {
                mImage          = view.FindViewById<ImageView>(Resource.Id.image_producto);
                mNombre         = view.FindViewById<TextView>(Resource.Id.nombre_producto);
                mMarcaCategoria = view.FindViewById<TextView>(Resource.Id.marca_categoria);
                //mPrecioAntes  = view.FindViewById<ImageView>(Resource.Id.image_producto_relacionado);
                //mPrecioOferta = view.FindViewById<ImageView>(Resource.Id.image_producto_relacionado);
                row             = view.FindViewById<LinearLayout>(Resource.Id.fila_producto);
            }
        }

        /// <summary>
        /// Ons the bind view holder.
        /// </summary>
        /// <param name="holder">Holder.</param>
        /// <param name="position">Position.</param>
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ProductoRelacionadoViewHolder miholder = holder as ProductoRelacionadoViewHolder;
            LinearLayout view = miholder.row;
            ProductosOfertasModelAndroid productoRelacionado = list[position];         
            miholder.mImage.SetImageBitmap(productoRelacionado.Imagen);
            miholder.mNombre.Text = productoRelacionado.Nombre;
            miholder.mMarcaCategoria.Text = productoRelacionado.Marca + " - " + productoRelacionado.Categoria;//Math.Round(sucursal.UserDistance, 1) + " Km";
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
            ProductoRelacionadoViewHolder viewholder = new ProductoRelacionadoViewHolder(card, onClick);

            viewholder.row.Click += (sender, e) =>
            {
                ProductosOfertasModelAndroid prodRelacionado = list[viewholder.AdapterPosition];
                productoDesdeRecicler = new List<object>();
                productoDesdeRecicler.Add(prodRelacionado.Id);
                productoDesdeRecicler.Add(prodRelacionado.Nombre);
                productoDesdeRecicler.Add(prodRelacionado.Marca);
                productoDesdeRecicler.Add(prodRelacionado.Departamento);
                productoDesdeRecicler.Add(prodRelacionado.Categoria);
                productoDesdeRecicler.Add(prodRelacionado.Subcategoria);
                productoDesdeRecicler.Add(prodRelacionado.Precioantes);
                productoDesdeRecicler.Add(prodRelacionado.Preciooferta);
                productoDesdeRecicler.Add(prodRelacionado.Imagen);            
                this.fragment.Activity.FinishActivity(100);
                AndroidDataManager.ProductoOferta = prodRelacionado;
         
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
            fragment.Activity.StartActivity(new Intent(fragment.Activity, typeof(DetalleProductoActivity)));
        }
    }
}
