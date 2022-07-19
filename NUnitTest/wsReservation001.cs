using System;
using System.ServiceModel.Channels;
using NUnit.Framework;
using AquardensNUnitTest;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;

namespace wsReservation
{
    public class Booking001 : Base001
    {
        protected iBooking_001Client Client = new iBooking_001Client();
        protected iBooking_002Client bookingClient = new iBooking_002Client();

        [Test]
        public async Task ControllaDisponibilita()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await Client.ControllaDisponibilitaAsync(baseRequest, new dcBkgFilter()
            {
                Qt = 1,
                Sesso = 1,
                IdListino = new IdBox()
                {
                    Id = "130300420171025439855100025227"
                },
                DataInizio = new DateTime(2022, 05, 06, 10, 0, 0),
                OraInizio = "10"
            });
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task Disdici()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await Client.DisdiciAsync(baseRequest, new IdBox());
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task Elimina()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await Client.EliminaAsync(baseRequest, new IdBox());
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task EliminaListaAttesa()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await Client.EliminaListaAttesaAsync(baseRequest, new IdBox());
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task Fruisci()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await Client.FruisciAsync(baseRequest, new IdBox(), "", "");
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task Prenota()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await Client.PrenotaAsync(baseRequest, new dcBkgPrenotRequest[]{});
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task PrenotaListaAttesa()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await Client.PrenotaListaAttesaAsync(baseRequest, new dcBkgPrenotRequest[] { });
            Print(esito);
            Assert.IsNotNull(esito);
        }
    }

    public class CommonElenchi001 : Base001
    {
        protected iCommonElenchi_001Client Client = new iCommonElenchi_001Client();

        [Test]
        public async Task GetPrenotazioniStaff()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await Client.GetPrenotazioniStaffAsync(baseRequest, new IdBox(), new dcReservationFilter());
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

            var esito = await Client.GetPrenotazioniUtenteAsync(baseRequest, new IdBox()
            {
                Id = "130300820180907331048630003707"
            }
            , new dcReservationFilter());
            Print(esito);
            Assert.IsNotNull(esito);
        }
    }

    public class PlanningAgende001: Base001
    {
        protected iPlanningAgende_001Client Client = new iPlanningAgende_001Client();

        [Test]
        public async Task GetAgende()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await Client.GetAgendeAsync(baseRequest, new dcPlanningRequest()
            {
                IdAnagrafica = new IdBox()
                {
                    Id = "130300820180907331048630003707"
                }
            });
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task PrenotaAgenda()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await Client.PrenotaAgendaAsync(baseRequest, new dcReservation());
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task PrenotaDaListaAttesa()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await Client.PrenotaDaListaAttesaAsync(baseRequest, new dcReservation());
            Print(esito);
            Assert.IsNotNull(esito);
        }
    }

    public class PlanningCommon001 : Base001
    {
        protected iPlanningCommon_001Client Client = new iPlanningCommon_001Client();

        [Test]
        public async Task DisdiciPrenotazione()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await Client.DisdiciPrenotazioneAsync(baseRequest, new IdBox());
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

            var esito = await Client.FruisciPrenotazioneAsync(baseRequest, "", "", "");
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

            var esito = await Client.GetItemReservationsAsync(baseRequest, new dcReservation(), new dcReservationFilter());
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

            var esito = await Client.SetReservationUsedAsync(baseRequest, new dcFruitionRequest());
            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}