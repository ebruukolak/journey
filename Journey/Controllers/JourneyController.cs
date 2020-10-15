using System;
using System.Threading.Tasks;
using Journey.Business.Services;
using Journey.Models;
using Microsoft.AspNetCore.Mvc;
using Journey.Business.Models.Requests;
using Journey.Business.Models.Responses;
using System.Linq;
using System.Collections.Generic;

namespace Journey.Controllers
{
    public class JourneyController: Controller
    {
        private readonly IJourneyService _journeyService;
        public JourneyController(IJourneyService journeyService)
        {
            _journeyService = journeyService;
        }

        public async Task<IActionResult> Search(RequestViewModel journeyViewModel)
        {
            var journeys = new JourneyResponseViewModel();
            if (ModelState.IsValid)
            {
                if(!string.IsNullOrEmpty(journeyViewModel.SessionId) && !string.IsNullOrEmpty(journeyViewModel.DeviceId))
                {
                     var journeysResponse = await _journeyService.GetBusjourneys(new GetJourneysRequest
                    {
                        DeviceSession=new DeviceSession
                        {
                            DeviceId=journeyViewModel.DeviceId,
                            SessionId=journeyViewModel.SessionId
                        },
                        Date=DateTime.Now,
                        Data=new JourneyRequest
                        {
                            DepartureDate=journeyViewModel.DepartureDate,
                            DestinationId=journeyViewModel.DestinationId,
                            OriginId=journeyViewModel.OriginId
                        },
                        Language="tr-TR"
                    });

                    journeys.Journeys= journeysResponse.Data.OrderBy(o=>o.Journey.Departure.ToShortTimeString()).Select(j=>new JourneyViewModel
                    {
                        OriginName=j.Journey.Origin,
                        DestinationName=j.Journey.Destination,
                        ArrivalTime=j.Journey.Arrival ?? DateTime.Now,
                        DepartureTime=j.Journey.Departure,
                        Price=j.Journey.OriginalPrice
                    }).ToList();
                    journeys.OriginLocation = journeysResponse.Data.First().OriginLocation;
                    journeys.DestinationLocation = journeysResponse.Data.First().DestinationLocation;
                    journeys.DepartureDate = journeyViewModel.DepartureDate;
                    journeys.OriginId = journeyViewModel.OriginId;
                    journeys.DestinationId = journeyViewModel.DestinationId;
                    journeys.SessionId = journeyViewModel.SessionId;
                    journeys.DeviceId = journeyViewModel.DeviceId;
                }
            }
            return View("_journey", journeys);
        }
    }
}
