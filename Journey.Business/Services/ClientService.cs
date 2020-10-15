using System;
using System.Threading.Tasks;
using Journey.Business.Models.Requests;
using Journey.Business.Models.Responses;
using Journey.Helpers;

namespace Journey.Business.Services
{
    public class ClientService : IClientService
    {
        public async Task<GetSessionResponse> GetSession(SessionRequest sessionRequest)
        {
            if (sessionRequest != null)
            {
                var service = new ServiceHelper<SessionRequest, GetSessionResponse>();
                return await service.PostAsync(sessionRequest, "client/getSession");
            }

            return null;
        }
    }
}
