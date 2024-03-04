using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINNO_FC.Models
{
    public class LoginResponse
    {
        [JsonProperty("_id")]
        public string? Username { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Position { get; set; }
        public string? Speed { get; set; }
        public string? Acceleration { get; set; }
        public string? Positioning { get; set; }
        public string? Shoot { get; set; }
        public string? ShortPass { get; set; }
        public string? LongPass { get; set; }
        public string? Vision { get; set; }
        public string? Crossing { get; set; }
        public string? TotalPoint { get; set; }
    }
}
