using System;
using System.Threading.Tasks;
using Journey.Business.Models.Requests;
using Journey.Business.Models.Responses;

namespace Journey.Business.Services
{
    public interface ILocationService
    {
        public Task<GetBusLocationsResponse> GetBusLocations(GetBusLocationRequest request);
    }
}
