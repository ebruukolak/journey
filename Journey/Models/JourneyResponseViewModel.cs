using System;
using System.Collections.Generic;

namespace Journey.Models
{
    public class JourneyResponseViewModel:BaseViewModel
    {
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }
        public List<JourneyViewModel> Journeys { get; set; }
    }

    public class JourneyViewModel
    {
        public string OriginName { get; set; }
        public string DestinationName { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime{ get; set; }
        public Decimal Price { get; set; }
       
    }
}
