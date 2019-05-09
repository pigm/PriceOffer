using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Apps.Common.Models.Modelo
{
    /// <summary>
    /// Departamento.
    /// </summary>
    public class Departamento
    {
        [JsonProperty("iddepartamento")]
        public int iddepartamento { get; set; }

        [JsonProperty("nombredepartamento")]
        public string nombredepartamento { get; set; }

        [JsonProperty("imagendepartamento")]
        public string imagendepartamento { get; set; }

        [JsonProperty("categorias")]
        public List<Categoria> categorias { get; set; }
    }
}
