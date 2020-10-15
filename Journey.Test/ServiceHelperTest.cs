using System;
using System.Threading.Tasks;
using Journey.Business.Models.Requests;
using Journey.Business.Models.Responses;
using Journey.Helpers;
using Xunit;

namespace Journey.Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task ServiceHelperTest()
        {
            //getsession Method
            /* var request = new SessionRequest
             {
                 Type=1,
                 Connection=new Connection { IpAddress= "145.214.41.21",Port= "5117" },
                 Browser=new Browser { Name="Chrome",Version= "47.0.0.12" }
             };*/

            //getbusjourneys Method
            /*var request = new GetJourneysRequest
            {
                DeviceSession = new DeviceSession
                {
                    SessionId = "PqtdftjloK3Kpka97+ILDzMa6D9740nggLiTzXiLlzA=",
                    DeviceId = "PqtdftjloK3Kpka97+ILDzMa6D9740nggLiTzXiLlzA="
                },
               Date= DateTime.Now,
               Language="tr-TR",
               Data=new JourneyRequest
               {
                   OriginId=349,
                   DestinationId=356,
                   DepartureDate=DateTime.Now
               }
            };*/

            //getbuslocations Method
            var request = new GetBusLocationRequest
            {
                DeviceSession = new DeviceSession { DeviceId = "PqtdftjloK3Kpka97+ILDzMa6D9740nggLiTzXiLlzA=", SessionId = "PqtdftjloK3Kpka97+ILDzMa6D9740nggLiTzXiLlzA=" },
                Date=DateTime.Now,
                Language="tr-TR"
            };
            var service = new ServiceHelper<GetBusLocationRequest, GetBusLocationsResponse>();
            var response =  await service.PostAsync(request, "location/getbuslocations");
            Assert.NotNull(response);
        }
    }
}
