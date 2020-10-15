using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Journey.Business.Models.Responses
{
    public class GetBusLocationsResponse:BaseResponse
    {
       [JsonProperty("data")]
       public List<BusLocationResponse> Data { get; set; }
    }

    public class BusLocationResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("parent-id")]
        public int ParentId { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("geo-location")]
        public GeoLocation GeoLocation { get; set; }
        [JsonProperty("tz-code")]
        public string TzCode { get; set; }
        [JsonProperty("weather-code")]
        public string WeatherCode { get; set; }
        [JsonProperty("rank")]
        public int? Rank { get; set; }
        [JsonProperty("reference-code")]
        public string ReferenceCode { get; set; }
        [JsonProperty("keywords")]
        public string Keywords { get; set; }

    }
    public class GeoLocation
    {
        [JsonProperty("latitude")]
        public double Lalatitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("zoom")]
        public string Zoom { get; set; }
    }
}
