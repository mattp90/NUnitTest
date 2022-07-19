using NUnit.Framework;
using System.Threading.Tasks;
using wsReservation;

namespace AquardensNUnitTest.Reservation
{
    public class iReservationConfig : Base001
    {
        protected iReservationConfigClient reservationConfigClient = new iReservationConfigClient();

        [Test]
        public async Task GetResources()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await reservationConfigClient.GetResourcesAsync(baseRequest);

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
