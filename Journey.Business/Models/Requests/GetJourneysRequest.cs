using System;
using Newtonsoft.Json;

namespace Journey.Business.Models.Requests
{
    public class GetJourneysRequest : BaseRequest
    {
      [JsonProperty("data")]
      public JourneyRequest Data { get; set; }
    }

    public class JourneyRequest
    {
        [JsonProperty("origin-id")]
        public int OriginId { get; set; }
        [JsonProperty("destination-id")]
        public int DestinationId { get; set; }
        [JsonProperty("departure-date")]
        public DateTime DepartureDate { get; set; }
    }
}
