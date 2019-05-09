using System;
namespace Apps.Common.Models.Modelo
{
    /// <summary>
    /// Productos ofertas.
    /// </summary>
    public class ProductosOfertasModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>The nombre.</value>
        public string Nombre { get; set; }
        /// <summary>
        /// Gets or sets the marca.
        /// </summary>
        /// <value>The marca.</value>
        public string Marca { get; set; }
        /// <summary>
        /// Gets or sets the departamento.
        /// </summary>
        /// <value>The departamento.</value>
        public string Departamento { get; set; }
        /// <summary>
        /// Gets or sets the categoria.
        /// </summary>
        /// <value>The categoria.</value>
        public string Categoria { get; set; }
        /// <summary>
        /// Gets or sets the subcategoria.
        /// </summary>
        /// <value>The subcategoria.</value>
        public string Subcategoria { get; set; }
        /// <summary>
        /// Gets or sets the precioantes.
        /// </summary>
        /// <value>The precioantes.</value>
        public int Precioantes { get; set; }
        /// <summary>
        /// Gets or sets the preciooferta.
        /// </summary>
        /// <value>The preciooferta.</value>
        public int Preciooferta { get; set; }
        /// <summary>
        /// Gets or sets the imagen.
        /// </summary>
        /// <value>The imagen.</value>
        public string Imagen { get; set; }
    }
}
