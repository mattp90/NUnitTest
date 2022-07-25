using NUnit.Framework;
using System.Threading.Tasks;
using wsReservation;

namespace AquardensNUnitTest_2.Reservation
{
    public class iCommonElenchi_001 : Base001
    {
        protected iCommonElenchi_001Client commonElenchiClient = new iCommonElenchi_001Client();

        [Test]
        public async Task GetPrenotazioniStaff()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await commonElenchiClient.GetPrenotazioniStaffAsync(baseRequest,
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

            var esito = await commonElenchiClient.GetPrenotazioniUtenteAsync(baseRequest,
                new IdBox() // Id Anagrafica
                { 
                    Id = "ACC000120220621454605180000088"
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
