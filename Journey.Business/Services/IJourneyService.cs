using System;
using System.Threading.Tasks;
using Journey.Business.Models.Requests;
using Journey.Business.Models.Responses;

namespace Journey.Business.Services
{
    public interface IJourneyService
    {
        public Task<GetJourneysResponse> GetBusjourneys(GetJourneysRequest request);
    }
}
