using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Journey.Business.Models.Responses
{
    public class GetJourneysResponse:BaseResponse
    {
        [JsonProperty("data")]
        public List<JourneyResponse> Data { get; set; }
    }

    public class JourneyResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("partner-id")]
        public int PartnerId { get; set; }
        [JsonProperty("partner-name")]
        public string PartnerName { get; set; }
        [JsonProperty("route-id")]
        public int RouteId { get; set; }
        [JsonProperty("bus-type")]
        public string BusType { get; set; }
        [JsonProperty("total-seats")]
        public int TotalSeats { get; set; }
        [JsonProperty("available-seats")]
        public int AvailableSeats { get; set; }
        [JsonProperty("journey")]
        public Journey Journey { get; set; }
        [JsonProperty("features")]
        public List<Feature> Features { get; set; }
        [JsonProperty("origin-location")]
        public string OriginLocation { get; set; }
        [JsonProperty("destination-location")]
        public string DestinationLocation { get; set; }
        [JsonProperty("is-active")]
        public bool IsActive { get; set; }
        [JsonProperty("origin-location-id")]
        public int OriginLocationId { get; set; }
        [JsonProperty("destination-location-id")]
        public int DestinationLocationId { get; set; }
        [JsonProperty("is-promoted")]
        public bool IsPromoted { get; set; }
        [JsonProperty("cancellation-offset")]
        public int? CancellationOffset { get; set; }
        [JsonProperty("has-bus-shuttle")]
        public bool HasBusShuttle { get; set; }
        [JsonProperty("disable-sales-without-gov-id")]
        public bool DisableSalesWithoutGovId { get; set; }
        [JsonProperty("display-offset")]
        public TimeSpan? DisplayOffset { get; set; }
        [JsonProperty("partner-rating")]
        public decimal? PertnerRating { get; set; }
    }
    public class Journey
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("stops")]
        public List<Stop> Stops { get; set; }
        [JsonProperty("origin")]
        public string Origin { get; set; }
        [JsonProperty("destination")]
        public string Destination { get; set; }
        [JsonProperty("departure")]
        public DateTime Departure { get; set; }
        [JsonProperty("arrival")]
        public DateTime? Arrival { get; set; }
        [JsonProperty("duration")]
        public TimeSpan? Duration { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("original-price")]
        public decimal OriginalPrice { get; set; }
        [JsonProperty("internet-price")]
        public decimal InternetPrice { get; set; }
        [JsonProperty("booking")]
        public string[] Booking { get; set; }
        [JsonProperty("bus-name")]
        public string BusName { get; set; }
        [JsonProperty("policy")]
        public Policy Policy { get; set; }
        [JsonProperty("features")]
        public string[] Features { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Stop
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("station")]
        public int? Station { get; set; }
        [JsonProperty("time")]
        public DateTime? Time { get; set; }
        [JsonProperty("is-origin")]
        public bool IsOrigin { get; set; }
        [JsonProperty("is-destination")]
        public bool IsDestination { get; set; }
    }

    public class Policy
    {
        [JsonProperty("max-seats")]
        public int? MaxSeats { get; set; }
        [JsonProperty("max-single")]
        public int? MaxSingle { get; set; }
        [JsonProperty("max-single-males")]
        public int? MaxSingleMales { get; set; }
        [JsonProperty("max-single-females")]
        public int? MaxSingleFemales { get; set; }
        [JsonProperty("mixed-genders")]
        public bool MixedGenders { get; set; }
        [JsonProperty("gov-id")]
        public bool GovId { get; set; }
        [JsonProperty("lht")]
        public bool Lht { get; set; }
    }
    public class Feature
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("priority")]
        public byte? Priority { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("is-promoted")]
        public bool IsPromoted { get; set; }
        [JsonProperty("back-color")]
        public string BackColor { get; set; }
        [JsonProperty("fore-color")]
        public string ForeColor { get; set; }
    }
}
