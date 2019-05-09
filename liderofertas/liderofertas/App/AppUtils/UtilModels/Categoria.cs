using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace liderofertas.AppUtils
{
    /// <summary>
    /// Categoria.
    /// </summary>
    public class Categoria
    {
        [JsonProperty("idcategoria")]
        public int idcategoria { get; set; }

        [JsonProperty("nombrecategoria")]
        public string nombrecategoria { get; set; }

        [JsonProperty("imagencategoria")]
        public string imagencategoria { get; set; }

        [JsonProperty("subcategorias")]
        public List<Subcategoria> subcategorias { get; set; }
    }
}
