using System;
using Newtonsoft.Json;

namespace Journey.Business.Models.Responses
{
    public class GetSessionResponse : BaseResponse
    {
        [JsonProperty("data")]
        public SessionResponse Data { get; set; }
    }

    public class SessionResponse
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }
        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
        [JsonProperty("affiliate")]
        public string Affiliate { get; set; }
        [JsonProperty("device-type")]
        public int DeviceType { get; set; }
    }
}
