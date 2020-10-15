using System;
using System.Threading.Tasks;
using Journey.Business.Models.Requests;
using Journey.Business.Models.Responses;
using Journey.Helpers;

namespace Journey.Business.Services
{
    public class JourneyService : IJourneyService
    {
        public async Task<GetJourneysResponse> GetBusjourneys(GetJourneysRequest request)
        {
            if (request != null)
            {
                var service = new ServiceHelper<GetJourneysRequest, GetJourneysResponse>();
                return await service.PostAsync(request, "journey/getbusjourneys");
            }
            return null;
        }
    }
}
