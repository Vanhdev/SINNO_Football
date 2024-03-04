using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINNO_FC.Models
{
    internal class LoginModel
    {
        [JsonProperty("_id")]
        public string? Username { get; set; }
        [JsonProperty("Password")]
        public string? Password { get; set; }
    }
}
