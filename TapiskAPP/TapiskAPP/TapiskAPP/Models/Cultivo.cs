using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TapiskAPP.Models
{
    public class Cultivo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Nombre { get; set; }

        [JsonProperty("growth_period")]
        public int PeriodoCrecimiento { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
        
        [JsonProperty("active_harvests")]
        public int CosechasActivas { get; set; }

    }
}
