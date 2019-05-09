using System;
using System.Collections.Generic;

namespace Apps.Common.Models.Modelo
{
    /// <summary>
    /// Subcategoria.
    /// </summary>
    public class Subcategoria
    {
        /// <summary>
        /// Gets or sets the idsubcategoria.
        /// </summary>
        /// <value>The idsubcategoria.</value>
        public int idsubcategoria { get; set; }

        /// <summary>
        /// Gets or sets the nombresubcategoria.
        /// </summary>
        /// <value>The nombresubcategoria.</value>
        public string nombresubcategoria { get; set; }

        /// <summary>
        /// Gets or sets the imagensubcategoria.
        /// </summary>
        /// <value>The imagensubcategoria.</value>
        public string imagensubcategoria { get; set; }

        /// <summary>
        /// Gets or sets the productos.
        /// </summary>
        /// <value>The productos.</value>
        public List<Producto> productos { get; set; }
    }
}
