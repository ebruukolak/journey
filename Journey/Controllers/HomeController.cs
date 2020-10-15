using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Journey.Models;
using Journey.Business.Services;
using Shyjus.BrowserDetection;
using Journey.Business.Models.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Journey.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientService _clientService;
        private readonly ILocationService _locationService;
        private readonly IBrowserDetector browserDetector;


        public HomeController(IClientService clientService, ILocationService locationService, IBrowserDetector browserDetector)
        {
            _clientService = clientService;
            _locationService = locationService;
            this.browserDetector = browserDetector;
        }

        public async Task<IActionResult> Index()
        {
            var model = new LocationsViewModel();
            var browser = this.browserDetector.Browser;
            if (browser != null)
            {
                var sessionResponse = await _clientService.GetSession(new SessionRequest
                {
                    Browser = new Business.Models.Requests.Browser
                    {
                        Name = browser != null ? browser.Name : "Chrome",
                        Version = browser != null ? browser.Version : "1.0.0.0"
                    },
                    Connection = new Business.Models.Requests.Connection
                    {
                        IpAddress = HttpContext.Request.Host.Host == "localhost" ? "127.0.0.1" : HttpContext.Request.Host.Host,
                        Port = HttpContext.Request.Host.Port.ToString()
                    },
                    Type = 1
                });

                if (sessionResponse != null)
                {

                    var busLocations = await _locationService.GetBusLocations(new GetBusLocationRequest
                    {
                        Date = DateTime.Today,
                        DeviceSession = new DeviceSession
                        {
                            DeviceId = sessionResponse.Data.DeviceId,
                            SessionId = sessionResponse.Data.SessionId
                        },
                        Language = "tr-TR"
                    });

                    model.Origins = busLocations.Data.Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.Id.ToString(),
                    }).ToList();
                    model.Destinations = busLocations.Data.Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.Id.ToString(),
                    }).ToList();
                    var today = DateTime.Today;
                    model.DepartureDate = today.AddDays(1);
                    model.SessionId = sessionResponse.Data.SessionId;
                    model.DeviceId = sessionResponse.Data.DeviceId;
                }
            }

            return View(model);
        }
        public async Task<IActionResult> MainPage(RequestViewModel request)
        {
            var model = new LocationsViewModel();
            if (request != null)
            {
                var busLocations = await _locationService.GetBusLocations(new GetBusLocationRequest
                {
                    Date = DateTime.Today,
                    DeviceSession = new DeviceSession
                    {
                        DeviceId = request.DeviceId,
                        SessionId = request.SessionId
                    },
                    Language = "tr-TR"
                });

                model.Origins = busLocations.Data.Select(o => new SelectListItem
                {
                    Text = o.Name,
                    Value = o.Id.ToString(),
                    Selected=o.Id==request.OriginId
                }).ToList();
                model.Destinations = busLocations.Data.Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString(),
                    Selected=d.Id==request.DestinationId
                }).ToList();
                var today = DateTime.Today;
                model.DepartureDate = today.AddDays(1);
                model.SessionId = request.SessionId;
                model.DeviceId = request.DeviceId;
            }
            return View("index",model);
        }
    }
}
