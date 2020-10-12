using System;
using Journey.Business.Models.Requests;
using Journey.Business.Models.Responses;
using Journey.Helpers;
using Xunit;

namespace Journey.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var request = new SessionRequest
            {
                Type=1,
                Connection=new Connection { IpAddress= "145.214.41.21",Port= "5117" },
                Browser=new Browser { Name="Chrome",Version= "47.0.0.12" }
            };

            var aa = new ServiceHelper<SessionRequest, SessionResponse>();
            var bb = aa.PostAsync(request, "client/getSession");
            Assert.NotNull(bb);
        }
    }
}
