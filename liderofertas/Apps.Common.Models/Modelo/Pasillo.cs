using System;
using System.Collections.Generic;

namespace Apps.Common.Models.Modelo
{
    /// <summary>
    /// Pasillo.
    /// </summary>
    public class Pasillo
    {
        /// <summary>
        /// Gets or sets the nombreproducto.
        /// </summary>
        /// <value>The nombreproducto.</value>
        public string nombrePasillo { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
        public string tag { get; set; }

        /// <summary>
        /// Gets or sets the imagen pasillo.
        /// </summary>
        /// <value>The imagen pasillo.</value>
        public string imagenPasillo { get; set; }

        /// <summary>
        /// Gets or sets the marcaproducto.
        /// </summary>
        /// <value>The marcaproducto.</value>
        public List<Subcategoria> subcategorias { get; set; }
    }
}
