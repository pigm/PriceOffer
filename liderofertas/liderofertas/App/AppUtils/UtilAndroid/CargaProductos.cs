using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Graphics;
using Apps.Common.Services.Delegate;
using liderofertas.Service;

namespace liderofertas.AppUtils
{
    /// <summary>
    /// Carga productos.
    /// </summary>
    public class CargaProductos
    {
        /// <summary>
        /// Cargas the productos ofertas company async.
        /// </summary>
        /// <returns>The productos ofertas company async.</returns>
        /// <param name="activity">Activity.</param>
        public static async Task CargaProductosOfertasCompanyAsync(Activity activity)
        {
            List<Apps.Common.Models.Modelo.ProductosOfertasModel>  pdsOfertas = new List<Apps.Common.Models.Modelo.ProductosOfertasModel>();
            List<ProductosOfertasModelAndroid> pdsOfertasModelAndroid = new List<ProductosOfertasModelAndroid>();
            StreamReader readerPO = new StreamReader(activity.Assets.Open("BD/ProductosOfertas.json"));
            string jsonPO = readerPO.ReadToEnd();
            var productosOfertas = await ServiceDelegate.Instance.GetProductosOfertas(jsonPO);
            if (productosOfertas.Success)
            {
                pdsOfertas = productosOfertas.Response as List<Apps.Common.Models.Modelo.ProductosOfertasModel>;
                foreach (var producto in pdsOfertas)
                {
                    byte[] imageBytes = Convert.FromBase64String(producto.Imagen);
                    Bitmap newImg = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    var streamImg = new MemoryStream();
                    newImg.Compress(Bitmap.CompressFormat.Jpeg, 15, streamImg);
                    ProductosOfertasModelAndroid productoOfertaModelAndroid = new ProductosOfertasModelAndroid
                    {
                        Id = producto.Id,
                        Nombre = producto.Nombre,
                        Marca = producto.Marca,
                        Departamento = producto.Departamento,
                        Categoria = producto.Categoria,
                        Subcategoria = producto.Subcategoria,
                        Precioantes = producto.Precioantes,
                        Preciooferta = producto.Preciooferta,
                        Imagen = newImg
                    };
                    pdsOfertasModelAndroid.Add(productoOfertaModelAndroid);
                }
                AndroidDataManager.ProductosOfertas = pdsOfertasModelAndroid;
            }
            else
            {
                ///Mensaje sin ofertas
            }
        }

        /// <summary>
        /// Cargas the ofertas unicas.
        /// </summary>
        /// <returns>The ofertas unicas.</returns>
        /// <param name="activity">Activity.</param>
        public static async Task CargaOfertasUnicas(Activity activity)
        {
            List<Apps.Common.Models.Modelo.ProductosOfertasUnicasModel> pdsOfertasUnicas = new List<Apps.Common.Models.Modelo.ProductosOfertasUnicasModel>();
            List<ProductosOfertasUnicasModelAndroid> pdsOfertasUnicasModelAndroid = new List<ProductosOfertasUnicasModelAndroid>();
            StreamReader reader = new StreamReader(activity.Assets.Open("BD/ProductosOfertasUnicas.json"));
            string json = reader.ReadToEnd();
            var productosOfertasUnicas = await ServiceDelegate.Instance.GetProductosOfertasUnicas(json);
            if (productosOfertasUnicas.Success)
            {
                pdsOfertasUnicas = productosOfertasUnicas.Response as List<Apps.Common.Models.Modelo.ProductosOfertasUnicasModel>;
                foreach (var prodOffer in pdsOfertasUnicas)
                {
                    byte[] imageBytes = Convert.FromBase64String(prodOffer.Imagen);
                    Bitmap newImg = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    var streamImg = new MemoryStream();
                    newImg.Compress(Bitmap.CompressFormat.Jpeg, 15, streamImg);
                    ProductosOfertasUnicasModelAndroid productoOfertaUnicaModelAndroid = new ProductosOfertasUnicasModelAndroid
                    {
                        Id = prodOffer.Id,
                        Nombreoferta = prodOffer.Nombreoferta, 
                        Exclusivointernet = prodOffer.Exclusivointernet,
                        Imagen = newImg
                    };
                    pdsOfertasUnicasModelAndroid.Add(productoOfertaUnicaModelAndroid);
                }
                AndroidDataManager.ProductosOfertasUnicas = pdsOfertasUnicasModelAndroid;
            }
            else
            {
                ///Mensaje sin ofertas
            }
        }

        /// <summary>
        /// Cargas the productos pasillo.
        /// </summary>
        /// <returns>The productos pasillo.</returns>
        /// <param name="activity">Activity.</param>
        public static async Task CargaProductosPasillo(Activity activity)
        {
            List<PasilloModelAndroid> listPasilloModelAndroid = new List<PasilloModelAndroid>();
            StreamReader reader = new StreamReader(activity.Assets.Open("BD/PasillosOfertas.json"));
            string json = reader.ReadToEnd();
            var productosOfertasPasillos = await ServiceDelegateAndroid.Instance.GetProductosOfertasPasillos(json);
            if (productosOfertasPasillos.Success)
            {
                List<ZonaPasillo> zonaPasillos = productosOfertasPasillos.Response as List<ZonaPasillo>;
                List<PasilloModelAndroid> pasillos = new List<PasilloModelAndroid>();
                zonaPasillos.ForEach((ZonaPasillo zonaPasillo) =>
                {
                    List<Subcategoria> subcategoriasLst = new List<Subcategoria>();
                    PasilloModelAndroid pasillo = new PasilloModelAndroid();
                    pasillo.nombrePasillo = zonaPasillo.pasillo;
                    byte[] imageBytes = Convert.FromBase64String(zonaPasillo.imagenpasillo);
                    Bitmap newImg = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    var streamImg = new MemoryStream();
                    newImg.Compress(Bitmap.CompressFormat.Jpeg, 15, streamImg);
                    pasillo.imagenPasillo = newImg;
                    pasillo.tag = zonaPasillo.tag;
                    List<Departamento> departamentos = zonaPasillo.departamentos;
                    departamentos.ForEach((Departamento depa) =>
                    {
                        var categorias = depa.categorias;
                        categorias.ForEach((Categoria categoria) =>
                        {
                            var subcategorias = categoria.subcategorias;

                            subcategorias.ForEach((Subcategoria subcategoria) =>
                            {
                                subcategoriasLst.Add(subcategoria);                                 
                            });
                        });
                        pasillo.subcategorias = subcategoriasLst;

                        AndroidDataManager.SubCategoriasFiltros = subcategoriasLst;
                    });
                    pasillos.Add(pasillo);
                   // AndroidDataManager.ZonasPasillos = zonaPasillos;
                    AndroidDataManager.Pasillos = pasillos;
                });
                if (AndroidDataManager.Pasillos != null)
                {
                    foreach (var productoPasillo in AndroidDataManager.Pasillos)
                    {
                        PasilloModelAndroid pasModelAndroid = new PasilloModelAndroid
                        {
                            nombrePasillo = productoPasillo.nombrePasillo,
                            tag = productoPasillo.tag,
                            imagenPasillo = productoPasillo.imagenPasillo,
                            subcategorias = productoPasillo.subcategorias
                        };
                        listPasilloModelAndroid.Add(pasModelAndroid);
                    }
                    AndroidDataManager.Pasillos = listPasilloModelAndroid;
                }
                else
                {
                    // no existen pasillos
                }

            }
        }

    }
}
