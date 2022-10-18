using NUnit.Framework;
using System.Threading.Tasks;
using wsCommerce;

namespace AquardensNUnitTest.Commerce
{
    public class Commerce : Base
    {
        [Test]
        public async Task Acquista()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
                // SessionId = "45614cea-c9e7-4d8a-9fc4-7b56795dc1ba"
            };

            TestContext.WriteLine($"Url: {CommerceClient.Endpoint.Address}");
            
            var esito = await CommerceClient.AcquistaAsync(baseRequest,
                new dcOrdineAcquisto()
                {
                    TipoDocumento = "FAT",
                    ControllaCup = false,
                    Numero = "",
                    DatiFatturazione = new dcAnagraficaDatiFatturazione()
                    {
                       CodiceDestinatario = "", 
                       PEC = "a",
                       Cognome = "Marco",
                       Nome = "Marchi",
                       IsPersonaFisica = false,
                       IsAzienda = true,
                       // CodiceFiscale = "MRCMRC90S10M172Z",
                       PartitaIva = "11111111111",
                       RagioneSociale = "Company srl",
                       Nazione = new InfoBox()
                       {
                           IdEsterno = "IT"
                       },
                       IndirizzoPredefinito = new dcAnagraficaIndirizzo()
                       {
                           Cap = "37100",
                           Comune = new InfoBox()
                           {
                               Descrizione = "San Giovanni Lupatoto"
                           },
                           Indirizzo = "Via G. Verdi",
                           Provincia = "VR"
                       }
                    },
                    Righe = new dcOrdineRiga[]
                    {
                        new dcOrdineRiga()
                        {
                            IdListino = new IdBox()
                            {
                                Id = "130301020220919779862380003868"
                            },
                            IdTariffaListino = new IdBox()
                            {
                                Id = "130301020220919780443260004010"
                            },
                            Importo = 46,
                            Quantita = 1,
                            Impianto = "1303"
                        }
                    }
                }
            );
            
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task AcquistaIscrizione()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await CommerceClient.AcquistaIscrizioneAsync(baseRequest,
                new dcOrdineIscrizione()
                {
                    IdListino = new IdBox()
                    {
                        Id = "",
                        IdEsterno = ""
                    },
                    NumeroOrdine = "",
                    TipoDocumento = ""
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task AcquistaSospesi()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await CommerceClient.AcquistaSospesiAsync(baseRequest,
                new dcOrdineSospesi()
                {
                    Numero = "",
                    Sospesi = new dcIncassoSospeso[] 
                    {
                        new dcIncassoSospeso()
                        {
                            Anagrafica = new InfoBox()
                            {
                                Id = "",
                                IdEsterno = ""
                            },
                            Costo = 0,
                            DataPagare = System.DateTime.MinValue,
                            IdIncassoSospeso = new InfoBox()
                            {
                                Id = "",
                                IdEsterno = ""
                            },
                            Impianto = "",
                            Listino = new InfoBox()
                            {
                                Descrizione = "",
                                Id = "",
                                IdEsterno = ""
                            },
                            Livello = new InfoBox()
                            {
                                Descrizione = "",
                                Id = "",
                                IdEsterno = ""
                            },
                            OrariFrequenza = new dcOrarioFrequenza[]
                            {
                                new dcOrarioFrequenza()
                                {
                                    Corso = new InfoBox()
                                    {
                                        Descrizione = "",
                                        Id = "",
                                        IdEsterno = ""
                                    },
                                    Giorno = 0,
                                    OraFine = "",
                                    OraInizio = ""
                                }
                            },
                            Pagare = 0,
                            TipoListino = 0,
                            TutoreMancante = false
                        }
                    }
                }
            );

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

            var esito = await CommerceClient.FruisciAsync(baseRequest,
                new dcOrdineAcquisto()
                {
                    ControllaCup = null,
                    Numero = "",
                    Righe = new dcOrdineRiga[]
                    {
                        new dcOrdineRiga()
                        {
                            IdListino = new IdBox()
                            {
                                Id = "",
                                IdEsterno = ""
                            },
                            IdOperatore = new IdBox()
                            {
                                Id = "",
                                IdEsterno = ""
                            },
                            IdPostazione = new IdBox()
                            {
                                Id = "",
                                IdEsterno = ""
                            },
                            IdReservation = "",
                            IdTariffa = new IdBox()
                            {
                                Id = "",
                                IdEsterno = ""
                            },
                            IdTariffaListino = new IdBox()
                            {
                                Id = "",
                                IdEsterno = ""
                            },
                            Impianto = "",
                            Importo = 0,
                            IsRegalo = false,
                            NominativoRegalo = "",
                            Quantita = null
                        }
                    }
                },
                new dcConto()
                {
                    IdConto = new IdBox()
                    { 
                        Id = "",
                        IdEsterno = ""
                    },
                    ImportoResiduo = null,
                    Riferimento = new InfoBox()
                    {
                        Descrizione = "",
                        Id = "",
                        IdEsterno = ""
                    },
                    TipoConto = null
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetNexiConfig()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await CommerceClient.GetNexiConfigAsync(baseRequest);

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetPayPalId()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await CommerceClient.GetPayPalIdAsync(baseRequest);

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task SetNexiConfig()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await CommerceClient.SetNexiConfigAsync(baseRequest,
                new dcNexiConfig()
                {
                    CodeContract = ""        
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task SetVoucherAsGift()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await CommerceClient.SetVoucherAsGiftAsync(baseRequest,
                new dcVoucherGiftRequest()
                {
                    Name = "",
                    VoucherCode = ""
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task SetVoucherUser()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await CommerceClient.SetVoucherUserAsync(baseRequest,
                "", // Voucher Code
                new IdBox() // Id Customer
                {
                    Id = "",
                    IdEsterno = ""
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task TestAcquistaIscrizione()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await CommerceClient.TestAcquistaIscrizioneAsync(baseRequest,
                new dcOrdineIscrizione()
                {
                     IdListino = new IdBox()
                     {
                         Id = "",
                         IdEsterno = ""
                     },
                     NumeroOrdine = "",
                     TipoDocumento = ""
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task TestCart()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await CommerceClient.TestCartAsync(baseRequest,
                new dcOrdineAcquisto()
                {
                    ControllaCup = null,
                    Numero = "",
                    Righe = new dcOrdineRiga[]
                    {
                        new dcOrdineRiga()
                        {
                            IdListino = new wsCommerce.IdBox()
                            {
                                Id = "130300420171025466674200032549"
                            },
                            IdReservation = "RSV000120220613366629410000009",
                            // IdTariffa = new wsCommerce.IdBox()
                            // {
                            //     Id = "130301020200102374347270001412"
                            // },
                            //Impianto = "1303",
                            // Importo = 0,
                            // IsRegalo = false,
                            // Quantita = 1
                        }
                    }
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
