using NUnit.Framework;
using System;
using System.Threading.Tasks;
using wsReservation;
using dcBaseRequest = wsReservation.dcBaseRequest;
using dcTariffa = wsReservation.dcTariffa;
using IdBox = wsReservation.IdBox;

namespace AquardensNUnitTest.Reservation
{
    public class Booking : Base
    {
        [Test]
        public async Task Conferma()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await BookingClient.ConfermaAsync(baseRequest,
                new IdBox() // Id Reservation
                {
                    Id = "", 
                    IdEsterno = ""
                },
                new IdBox() // Id Ordine
                {
                    Id = "",
                    IdEsterno = ""
                });

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

            var esito = await BookingClient.EliminaAsync(baseRequest,
                new IdBox()
                {
                    Id = "RSV000120220908514721500000234"
                },
                new IdBox()
                );
            
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetCodicePrenotazione()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await BookingClient.GetCodicePrenotazioneAsync(baseRequest);

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetDisponibilita()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
                // SessionId = "45614cea-c9e7-4d8a-9fc4-7b56795dc1ba"
            };

            var result = await BookingClient.GetDisponibilitaAsync(baseRequest,
                new dcBkgDispRequest()
                {
                    DataInizio = new DateTime(2022, 10, 1, 0, 0, 0),
                    DataFine = new DateTime(2022, 10, 31, 23, 59, 59),
                    IdListino = new IdBox()
                    {
                        Id = "130301020220913612840040003272"
                    }
                }
            );

            Print(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task Prenota()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto
                // , SessionId = "9ff2ea57-22e4-4618-b1eb-b7788130c9fb"
                , SessionId = SessionId
            };

            var esito = await BookingClient.PrenotaAsync(baseRequest,
                new dcBkgPrenotRequest[]
                {
                    new dcBkgPrenotRequest()
                    {
                        DataOraInizio = new DateTime(2022, 9, 12, 13, 50, 0),
                        DataOraFine = new DateTime(2022, 9, 12, 14, 10, 0),
                        IdAnagrafica = new IdBox()
                        {
                            Id = "ACC000120220907390016250000026"
                        },
                        IdListino = new IdBox()
                        {
                            Id = "130300420171025443629770025427"
                        },
                        Qt = 1,
                        Risorsa = new dcBkgRisorsa()
                        {
                            Id = new IdBox()
                            { 
                                Id = "130300420171025409880430007677"
                            }
                        },
                        Tariffa = new dcTariffa()
                        {
                            IdTariffaListino = new IdBox()
                            {
                                Id = "130301020200102383622090017374"
                            }
                        },
                        TipoConferma = 0, 
                        TipoPagamento = 2,
                        IdVoucher = new IdBox()
                        {
                            Id = "COM000120220908379160720000018"
                        }
                    }
                },
                new IdBox()
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
