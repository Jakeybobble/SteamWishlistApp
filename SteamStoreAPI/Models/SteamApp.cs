using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SteamStoreAPI.Models {
    public class SteamApp {
        [JsonPropertyName("name")]
        public string Title { get; set; }
        public string Id { get; set; }
    }
}
