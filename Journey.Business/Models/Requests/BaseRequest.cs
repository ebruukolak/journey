using System;
using Newtonsoft.Json;

namespace Journey.Business.Models.Requests
{
    public class BaseRequest
    {        
       [JsonProperty("device-session")]
        public DeviceSession DeviceSession{ get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
    }

    public class DeviceSession
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }
        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    } 
}
