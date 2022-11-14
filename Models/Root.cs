using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AirQuality.Models
{
    public class Root
    {
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }
        [JsonPropertyName("city")]
        public List<City> city { get; set; }
        [JsonPropertyName("country")]
        public List<Country> country { get; set; }
    }

    
}
