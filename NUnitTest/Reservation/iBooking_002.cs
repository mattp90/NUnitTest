using NUnit.Framework;
using System;
using System.Threading.Tasks;
using wsReservation;

namespace AquardensNUnitTest.Reservation
{
    public class iBooking002 : Base001
    {
        protected iBooking_002Client bookingClient = new iBooking_002Client();

        [Test]
        public async Task Conferma()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await bookingClient.ConfermaAsync(baseRequest,
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

            var esito = await bookingClient.EliminaAsync(baseRequest,
                new IdBox() // Id Reservation
                {
                    Id = "RSV000120220719624895120000011",
                    IdEsterno = ""
                },
                new IdBox() // Id Ordine
                //{
                //    Id = "RSV000120220609595094060000086",
                //    IdEsterno = ""
                //}
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

            var esito = await bookingClient.GetCodicePrenotazioneAsync(baseRequest);

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetDisponibilita()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                // SessionId = "45614cea-c9e7-4d8a-9fc4-7b56795dc1ba"
                SessionId = SessionId
            };

            var esito = await bookingClient.GetDisponibilitaAsync(baseRequest,
                new dcBkgDispRequest()
                {
                    DataInizio = new DateTime(2022, 7, 14, 8, 0, 0),
                    DataFine = new DateTime(2022, 7, 31, 20, 0, 0),
                    IdAnagrafica = new IdBox()
                    {
                        Id = "ACC000120220607458821350000074"
                        // IdEsterno = ""
                    },
                    IdListino = new IdBox()
                    {
                        Id = "130300420171025443104150025354"
                        // IdEsterno = ""
                    },
                    // OperatorSex = "",
                    OraAlle = new DateTime(2022, 6, 10, 20, 0, 0),
                    OraDalle = new DateTime(2022, 6, 10, 16, 0, 0),
                    // Risorse = new IdBox[] 
                    // {
                    //     new IdBox()
                    //     {
                    //         Id = "",
                    //         IdEsterno = ""
                    //     }
                    // }
                });

            Print(esito);
            Assert.IsNotNull(esito);
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

            var esito = await bookingClient.PrenotaAsync(baseRequest,
                new dcBkgPrenotRequest[]
                {
                    new dcBkgPrenotRequest()
                    {
                        // Cellulare = "",
                        // CodicePrenotazione = "",
                        DataOraInizio = new DateTime(2022, 7, 22, 18, 10, 0),
                        DataOraFine = new DateTime(2022, 7, 22, 18, 30, 0),
                        IdAnagrafica = new IdBox()
                        {
                            Id = "ACC000120220621454605180000088",
                            IdEsterno = ""
                        },
                        // IdCategoriaComponente = "",
                        // IdHotelPrenotazione = new IdBox()
                        // {
                        //     Id = "",
                        //     IdEsterno = ""
                        // },
                        // IdHotelReservation = new IdBox()
                        // {
                        //     Id = "",
                        //     IdEsterno = ""
                        // },
                        // IdIscrizioneTrattamento = new IdBox()
                        // {
                        //     Id = "",
                        //     IdEsterno = ""
                        // },
                        IdListino = new IdBox()
                        {
                            Id = "130300420171025443104150025354",
                            IdEsterno = ""
                        },
                        // IdPacchetto = new IdBox()
                        // {
                        //     Id = "",
                        //     IdEsterno = ""
                        // },
                        IdVoucher = new IdBox()
                        {
                            Id = "COM000120220719568841840000075",
                            IdEsterno = ""
                        },
                        // IsFruita = null,
                        // Nominativo = "",
                        // Nota = "",
                        Qt = 1,
                        // QtFemmine = null,
                        // QtMaschi = null,
                        Risorsa = new dcBkgRisorsa()
                        {
                            // Descrizione = "",
                            Id = new IdBox()
                            { 
                                Id = "130300420171025409880430007677",
                                IdEsterno = ""
                            }
                            // Sesso = "",
                            // Tipo = null
                        },
                        Tariffa = new dcTariffa()
                        {
                            // Descrizione = "",
                            Id = new IdBox()
                            {
                                Id = "130301020200102374347270001412",
                                // IdEsterno = ""
                            }
                            // IdTariffaListino = new IdBox()
                            // {
                            //     Id = "",
                            //     IdEsterno = ""
                            // },
                            // Importo = 0,
                            // Rate = null,
                            // ScontoAbilitato = null
                        },
                        // TipoAnagrafica = null,
                        TipoConferma = 0, 
                        TipoPagamento = 2
                    }
                },
                new IdBox() // Id Ordine
                {
                    Id = "", 
                    IdEsterno = ""
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
