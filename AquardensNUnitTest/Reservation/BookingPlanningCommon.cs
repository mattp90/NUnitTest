using NUnit.Framework;
using System.Threading.Tasks;
using wsReservation;

namespace AquardensNUnitTest.Reservation
{
    public class BookingPlanningCommon : Base
    {
        [Test]
        public async Task DisdiciPrenotazione()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await BookingPlanningCommonClient.DisdiciPrenotazioneAsync(baseRequest,
                new IdBox() // Id Reservation
                {
                    Id = "RSV000120220713351484210000014"
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task FruisciPrenotazione()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await BookingPlanningCommonClient.FruisciPrenotazioneAsync(baseRequest,
                "", // Id Reservation
                "", // Id Operatore
                ""  // Nota
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetItemReservations()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await BookingPlanningCommonClient.GetItemReservationsAsync(baseRequest,
                new dcReservationItem()
                { 
                    IdOrario = new IdBox()
                    {
                        Id = "",
                        IdEsterno = ""
                    },
                    Item = new InfoBox()
                    {
                        Descrizione = "",
                        Id = "",
                        IdEsterno = ""
                    },
                    ItemPrenotStatus = null,
                    Livello = new InfoBox()
                    {
                        Descrizione = "",
                        Id = "",
                        IdEsterno = ""
                    },
                    Posti = null,
                    PostiOccupati = null,
                    Tipo = null
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
        public async Task SetReservationUsed()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await BookingPlanningCommonClient.SetReservationUsedAsync(baseRequest,
                new dcFruitionRequest()
                {
                    IdReservation = new IdBox[]
                    {
                        new IdBox()
                        {
                            Id = "",
                            IdEsterno = ""
                        }
                    },
                    IdStaff = new IdBox()
                    {
                        Id = "",
                        IdEsterno = ""
                    },
                    Note = ""
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
