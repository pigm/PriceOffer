using System;
using System.Collections.Generic;
using Android.Graphics;

namespace liderofertas.AppUtils
{
    public class ZonaPasillo
    {
        /// <summary>
        /// Gets or sets the codlocal.
        /// </summary>
        /// <value>The codlocal.</value>
        public int codlocal { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
        public string tag { get; set; }

        /// <summary>
        /// Gets or sets the pasillo.
        /// </summary>
        /// <value>The pasillo.</value>
        public string pasillo { get; set; }

        /// <summary>
        /// Gets or sets the imagen pasillo.
        /// </summary>
        /// <value>The imagen pasillo.</value>
        public string imagenpasillo { get; set; }

        /// <summary>
        /// Gets or sets the departamentos.
        /// </summary>
        /// <value>The departamentos.</value>
        public List<Departamento> departamentos { get; set; }
    }
}
