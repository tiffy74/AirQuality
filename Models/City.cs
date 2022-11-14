using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AirQuality.Models
{
    public class City
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("city")]
        public string city { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("locations")]
        public int Locations { get; set; }

        [JsonPropertyName("firstUpdated")]
        public DateTime FirstUpdated { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        [JsonPropertyName("parameters")]
        public List<string> Parameters { get; set; }
    }
}
