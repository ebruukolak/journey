using System;
using System.Threading.Tasks;
using Journey.Business.Models.Requests;
using Journey.Business.Models.Responses;
using Journey.Helpers;

namespace Journey.Business.Services
{
    public class LocationService : ILocationService
    {
        public async Task<GetBusLocationsResponse> GetBusLocations(GetBusLocationRequest request)
        {
            if (request != null)
            {
                var service = new ServiceHelper<GetBusLocationRequest, GetBusLocationsResponse>();
                return await service.PostAsync(request, "location/getbuslocations");
            }
            return null;
        }
    }
}
