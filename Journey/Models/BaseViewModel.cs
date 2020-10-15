using System;
namespace Journey.Models
{
    public class BaseViewModel
    {
        public string SessionId { get; set; }
        public string DeviceId { get; set; }
        public DateTime DepartureDate { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }

    }
}
