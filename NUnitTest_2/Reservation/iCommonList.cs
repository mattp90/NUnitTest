using NUnit.Framework;
using System.Threading.Tasks;
using wsReservation;

namespace AquardensNUnitTest_2.Reservation
{
    public class iCommonList : Base001
    {
        protected iCommonListsClient commonListClient = new iCommonListsClient();

        [Test]
        public async Task GetReservations()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await commonListClient.GetReservationsAsync(baseRequest,
                new dcReservationRequest()
                { 
                    // DateEnd = null,
                    // DateStart = null,
                    // IdAcquisto = new IdBox()
                    // {
                    //     Id = "",
                    //     IdEsterno = ""
                    // },
                    // IdMember = new IdBox()
                    // {
                    //     Id = "",
                    //     IdEsterno = ""
                    // },
                    // IdReservation = new IdBox()
                    // {
                    //     Id = "RSV000120220608589636410000062"
                    // },
                    // Resources = new dcResource[] 
                    // {
                    //     new dcResource()
                    //     {
                    //         Gender = "",
                    //         Item = new InfoBox()
                    //         {
                    //             Descrizione = "",
                    //             Id = "",
                    //             IdEsterno = ""
                    //         }
                    //     }
                    // },
                    // TimeEnd = null,
                    // TimeStart = null,
                    TipoAcquisto = 1,
                    Types = new int[] { 2 }
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
