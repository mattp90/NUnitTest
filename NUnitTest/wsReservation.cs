using System;
using NUnit.Framework;
using AquardensNUnitTest;
using System.Threading.Tasks;

namespace wsReservation
{
    public class Booking : Base
    {
        protected iBookingClient Client = new iBookingClient();

        [Test]
        public async Task Disdici()
        {
            var esito = await Client.DisdiciAsync(SessionId, Impianto, new IdBox()
            {
                Id = "130300620191107439696590023167"
            });
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task Elimina()
        {
            await Client.EliminaAsync(null, null, null);
        }

        [Test]
        public async Task Fruisci()
        {
            await Client.FruisciAsync(null, null, null, null, null);
        }

        [Test]
        public async Task Prenota()
        {
            var prenotazione = new dcBkgPrenotRequest()
            {
                Cellulare = "+393402807018",
                Nominativo = "Prenotazione Test",
                Nota = "nota per la prenotazione test",
                Qt = 1,
                // Risorsa = null,
                Tariffa = new dcTariffa()
                {
                    Id = new IdBox()
                    {
                        Id ="130301020200102374347270001412"
                    }
                },
                CodicePrenotazione = null,
                IdAnagrafica = new IdBox()
                {
                    Id = "ANA000120220503515542470000007"
                },
                IdListino = new IdBox()
                {
                    Id = "130300420171025437265890024745"
                },
                // IdPacchetto = null,
                // IdVoucher = null,
                IsFruita = false,
                QtFemmine = 0,
                QtMaschi = 1,
                // TipoAnagrafica = null,
                // TipoConferma = null,
                // TipoPagamento = null,
                DataOraFine = DateTime.Now,
                DataOraInizio = DateTime.Now.AddHours(2),
                // IdCategoriaComponente = null,
                // IdHotelPrenotazione = null,
                // IdHotelReservation = null,
                // IdIscrizioneTrattamento = null
            };
            var esito = await Client.PrenotaAsync(SessionId, Impianto, new dcBkgPrenotRequest[]{ prenotazione });
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task PrenotaListaAttesa()
        {
            await Client.PrenotaListaAttesaAsync(null, null, null);
        }
    }

    public class BookingConfig : Base
    {
        protected iBookingConfigClient Client = new iBookingConfigClient();

        [Test]
        public async Task GetServiceConfig()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await Client.GetServiceConfigAsync(baseRequest, new IdBox());
            Print(esito);
            Assert.IsNotNull(esito);
        }
    }

    public class CommonElenchi : Base
    {
        protected iCommonElenchiClient Client = new iCommonElenchiClient();

        [Test]
        public async Task GetPrenotazioniStaff()
        {
            var esito = await Client.GetPrenotazioniStaffAsync(SessionId, Impianto, new IdBox(), new dcReservationFilter()
            {
                TipiPrenotazioni = new int[] {1}
            });
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetPrenotazioniUtente()
        {
            var esito = await Client.GetPrenotazioniUtenteAsync(SessionId, Impianto, new IdBox() {
                Id = "ANA000120220415570028060000037"
            }, new dcReservationFilter());
            Print(esito);
            Assert.IsNotNull(esito);
        }
    }

    public partial class CommonLists : Base
    {
        protected iCommonListsClient Client = new iCommonListsClient();

        [Test]
        public async Task GetReservations()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await Client.GetReservationsAsync(baseRequest, new dcReservationRequest()
                {
                    IdReservation = new IdBox()
                    {
                        Id = "130300820180918550079230064052"
                    }
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }

    public class PlanningAgende : Base
    {
        protected iPlanningAgendeClient Client = new iPlanningAgendeClient();

        [Test]
        public async Task GetAgende()
        {
            var esito = await Client.GetAgendeAsync(SessionId, Impianto, new dcPlanningRequest()
            {
                IdListino = new IdBox()
                {
                    Id = "130300420171025437265890024745"
                },

            });
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task PrenotaAgende()
        {
            var esito = await Client.PrenotaAgendaAsync(SessionId, Impianto, new dcReservation());
            Print(esito);
            Assert.IsNotNull(esito);
        }
    }

    public class PlanningCommon : Base
    {
        protected iPlanningCommonClient Client = new iPlanningCommonClient();

        [Test]
        public async Task DisdiciPrenotazione()
        {
            var esito = await Client.DisdiciPrenotazioneAsync(SessionId, Impianto, new IdBox());
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task FruisciPrenotazione()
        {
            var esito = await Client.FruisciPrenotazioneAsync(SessionId, Impianto, "", "", "");
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetItemReservations()
        {
            var reservation = new dcReservation()
            {
                IdReservation = new IdBox()
                {
                    Id = "130300820180907335158280001626"
                }
            };

            var esito = await Client.GetItemReservationsAsync(SessionId, Impianto, reservation, new dcReservationFilter()
            {
                IdReservation = new IdBox()
                {
                    IdEsterno = "130300820180907335158280001626"
                }
            });
            Print(esito);
            Assert.IsNotNull(esito);
        }
    }

    public class PlanningCorsi : Base
    {
        private iPlanningCorsiClient Client = new iPlanningCorsiClient();

        [Test]
        public async Task RecuperiConta()
        {
            var baseRequest = new dcBaseRequest()
            {
                SessionId = SessionId,
                Impianto = Impianto
            };
            var esito = await Client.RecuperiContaAsync(baseRequest, new IdBox()
            {
                Id = ""
            });
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task RecuperiGetItems()
        {
            var baseRequest = new dcBaseRequest()
            {
                SessionId = SessionId,
                Impianto = Impianto
            };

            var esito = await Client.RecuperiGetItemsAsync(baseRequest, new dcPlanningRecuperiItemFilter()
            {
                MaxResults = 100
            });
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task RecuperiInsert()
        {
            var baseRequest = new dcBaseRequest()
            {
                SessionId = SessionId,
                Impianto = Impianto
            };

            var esito = await Client.RecuperiInsertAsync(baseRequest, new dcReservation()
            {
                IdReservation = new IdBox()
                {
                    Id = "130300820180907335158280001626"
                }
            });
            Print(esito);
            Assert.IsNotNull(esito);
        }
    }

    public class ReservationConfig : Base
    {
        protected iReservationConfigClient Client = new iReservationConfigClient();

        [Test]
        public async Task GetResources()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await Client.GetResourcesAsync(baseRequest);

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}