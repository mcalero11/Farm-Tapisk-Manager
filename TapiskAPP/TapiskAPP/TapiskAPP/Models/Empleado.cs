using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TapiskAPP.Models
{
    public class Empleado
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Nombre { get; set; }
        [JsonProperty("second_name")]
        public string Apellido { get; set; }
        [JsonProperty("hiring_date")]
        public string FechaContratacion { get; set; }
        [JsonProperty("active")]
        public bool Activo { get; set; }
        [JsonProperty("referred")]
        public int Referido { get; set; }
        [JsonProperty("position")]
        public Cargo Cargo { get; set; }
    }
    
}
