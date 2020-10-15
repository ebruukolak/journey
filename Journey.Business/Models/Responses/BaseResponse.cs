using System;
using Journey.Business.Enums;
using Newtonsoft.Json;

namespace Journey.Business.Models.Responses
{
    public class BaseResponse
    {
        [JsonProperty("status")]
        public ResponseStatus Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("user-message")]
        public string UserMessage { get; set; }
        [JsonProperty("api-request-id")]
        public string ApiRequestId { get; set; }
        [JsonProperty("controller")]
        public string Controller { get; set; }
        [JsonProperty("client-request-id")]
        public string ClientRequestId { get; set; }
    }
}
