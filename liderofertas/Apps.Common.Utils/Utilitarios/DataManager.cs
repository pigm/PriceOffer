using System.Collections.Generic;
using Apps.Common.Models.Modelo;

namespace Apps.Common.Utils.Utilitarios
{
    /// <summary>
    /// Data manager.
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// Gets or sets the receta seleccionada.
        /// </summary>
        /// <value>The receta seleccionada.</value>
        public static bool IsAnonimo { get; set; }
        public static List<ProductosOfertasModel> ProductosOfertas { get; set; }
        public static List<ProductosOfertasUnicasModel> ProductosOfertasUnicas { get; set; }
        public static ProductosOfertasModel ProductoOferta { get; set; }
        public static List<Departamento> Departamentos { get; set; }
        public static List<Categoria> Categorias { get; set; }
        public static List<Subcategoria> SubCategoriasFiltros = new List<Subcategoria>();
        public static List<Pasillo> Pasillos { get; set; }
        public static List<ZonaPasillo> ZonasPasillos { get; set; }
        public static List<Producto> TotalProductosPasillo = new List<Producto>();
        public static List<Producto> ProductosXsubcategoria { get; set; }
        public static Subcategoria SubCategoriaXsubcategoria { get; set; }
        public static Producto ProductoPasillo { get; set; }
    }
}