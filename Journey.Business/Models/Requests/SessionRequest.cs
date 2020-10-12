using System;
using Newtonsoft.Json;

namespace Journey.Business.Models.Requests
{
    public class SessionRequest
    {
        private int? _type { get; set; }
        [JsonProperty("type")]
        public int Type
        {
            get
            {
                return _type ?? 7;
            }
            set
            {
                _type = value;
            }

        }
        [JsonProperty("connection")]
        public Connection Connection { get; set; }
        [JsonProperty("browser")]
        public Browser Browser { get; set; }
    }

    public class Connection
    {
        [JsonProperty("ip-address")]
        public string IpAddress { get; set; }
        [JsonProperty("port")]
        public string Port { get; set; }
    }

    public class Browser
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        private string _version { get; set; }
        [JsonProperty("version")]
        public string Version
        {
            get
            {
                return _version ?? "1.0.0.0";
            }
            set
            {
                _version = value;
            }
        }
    }
}
