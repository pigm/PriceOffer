﻿using System;
namespace Apps.Common.Models.Modelo
{
    /// <summary>
    /// Productos ofertas unicas model.
    /// </summary>
    public class ProductosOfertasUnicasModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the nombreoferta.
        /// </summary>
        /// <value>The nombreoferta.</value>
        public string Nombreoferta { get; set; }
        /// <summary>
        /// Gets or sets the imagen.
        /// </summary>
        /// <value>The imagen.</value>
        public string Imagen { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="T:Apps.Common.Models.Modelo.ProductosOfertasUnicasModel"/> is exclusivointernet.
        /// </summary>
        /// <value><c>true</c> if exclusivointernet; otherwise, <c>false</c>.</value>
        public bool Exclusivointernet { get; set; }
    }
}
