using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Journey.Models
{
    public class LocationsViewModel:BaseViewModel
    {
        public int OriginId { get; set; }
        public List<SelectListItem> Origins { get; set; }
        public List<SelectListItem> Destinations { get; set; }
        public int DestinationId { get; set; }
    }
}
