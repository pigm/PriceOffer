using System;
namespace Apps.Common.Models.Modelo
{
    /// <summary>
    /// Producto.
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// Gets or sets the nombreproducto.
        /// </summary>
        /// <value>The nombreproducto.</value>
        public string nombreproducto { get; set; }

        /// <summary>
        /// Gets or sets the marcaproducto.
        /// </summary>
        /// <value>The marcaproducto.</value>
        public string marcaproducto { get; set; }

        /// <summary>
        /// Gets or sets the precioantes.
        /// </summary>
        /// <value>The precioantes.</value>
        public int precioantes { get; set; }

        /// <summary>
        /// Gets or sets the preciooferta.
        /// </summary>
        /// <value>The preciooferta.</value>
        public int preciooferta { get; set; }

        /// <summary>
        /// Gets or sets the imagen.
        /// </summary>
        /// <value>The imagen.</value>
        public string imagen { get; set; }

        /// <summary>
        /// Gets or sets the idproducto.
        /// </summary>
        /// <value>The idproducto.</value>
        public int idproducto { get; set; }
    }
}
