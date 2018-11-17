using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TapiskAPP.Models
{
    public class Cargo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Nombre { get; set; }

        [JsonProperty("is_permanent")]
        public bool EsPermanente { get; set; }

        [JsonProperty("active")]
        public bool Activo { get; set; }
    }
}
