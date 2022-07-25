using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wsReservation;

namespace AquardensNUnitTest_2.Reservation
{
    public class iPlanningCommon_001 : Base001
    {
        protected iPlanningCommon_001Client planningCommonClient = new iPlanningCommon_001Client();

        [Test]
        public async Task DisdiciPrenotazione()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await planningCommonClient.DisdiciPrenotazioneAsync(baseRequest,
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

            var esito = await planningCommonClient.FruisciPrenotazioneAsync(baseRequest,
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

            var esito = await planningCommonClient.GetItemReservationsAsync(baseRequest,
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

            var esito = await planningCommonClient.SetReservationUsedAsync(baseRequest,
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
