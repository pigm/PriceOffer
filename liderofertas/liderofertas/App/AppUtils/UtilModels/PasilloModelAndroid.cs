using System;
using System.Collections.Generic;
using Android.Graphics;

namespace liderofertas.AppUtils
{
    public class PasilloModelAndroid
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
        public Bitmap imagenPasillo { get; set; }

        /// <summary>
        /// Gets or sets the marcaproducto.
        /// </summary>
        /// <value>The marcaproducto.</value>
        public List<Subcategoria> subcategorias { get; set; }
    }
}
