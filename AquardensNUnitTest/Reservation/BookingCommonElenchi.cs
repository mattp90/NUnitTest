using NUnit.Framework;
using System.Threading.Tasks;
using wsReservation;

namespace AquardensNUnitTest.Reservation
{
    public class BookingCommonElenchi : Base
    {
        [Test]
        public async Task GetPrenotazioniStaff()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await BookingCommonElenchiClient.GetPrenotazioniStaffAsync(baseRequest,
                new IdBox() // Id Staff
                {
                    Id = "",
                    IdEsterno = ""
                },
                new dcReservationFilter()
                {
                    DataFine = null,
                    DataInizio = null,
                    IdReservation = new IdBox()
                    {
                        Id = "",
                        IdEsterno = ""
                    },
                    TipiPrenotazioni = new int[] { }
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetPrenotazioniUtente()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await BookingCommonElenchiClient.GetPrenotazioniUtenteAsync(baseRequest,
                new IdBox() // Id Anagrafica
                { 
                    Id = "ACC000120220907390016250000026"
                    // IdEsterno = ""
                },
                new dcReservationFilter()
                // {
                //     DataFine = null,
                //     DataInizio = null,
                //     IdReservation = new IdBox()
                //     {
                //         Id = "",
                //         IdEsterno = ""
                //     },
                //     TipiPrenotazioni = new int[] { }
                // }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
