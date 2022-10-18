using NUnit.Framework;
using System.Threading.Tasks;
using wsReservation;

namespace AquardensNUnitTest.Reservation
{
    public class BookingReservationConfig : Base
    {
        [Test]
        public async Task GetResources()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await BookingReservationConfigClient.GetResourcesAsync(baseRequest);

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
