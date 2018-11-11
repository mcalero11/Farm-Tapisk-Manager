using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TapiskAPP.Models
{
    public class Usuario
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("employee")]
        public Empleado Empleado { get; set; }
    }
}
