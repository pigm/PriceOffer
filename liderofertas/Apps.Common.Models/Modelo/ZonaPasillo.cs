using System;
using System.Collections.Generic;

namespace Apps.Common.Models.Modelo
{
    /// <summary>
    /// Zona pasillo.
    /// </summary>
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
