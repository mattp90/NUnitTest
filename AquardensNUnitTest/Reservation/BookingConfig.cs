using NUnit.Framework;
using System.Threading.Tasks;
using wsReservation;

namespace AquardensNUnitTest.Reservation
{
    public class BookingConfig : Base
    {
        [Test]
        public async Task GetServiceConfig()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await BookingConfigClient.GetServiceConfigAsync(baseRequest, 
                new IdBox() // Id Service
                { 
                    Id = "130300420171025439855100025227",
                    IdEsterno = ""
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
