using NUnit.Framework;
using System.Threading.Tasks;
using wsCommerce;

namespace AquardensNUnitTest_2.Commerce
{
    public class iCommerce_001 : Base001
    {
        protected iCommerce_001Client commerceClient = new iCommerce_001Client();

        [Test]
        public async Task Acquista()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
                // SessionId = "45614cea-c9e7-4d8a-9fc4-7b56795dc1ba"
            };

            var esito = await commerceClient.AcquistaAsync(baseRequest,
                new dcOrdineAcquisto()
                {
                    TipoDocumento = "FAT",
                    ControllaCup = false,
                    // ControllaCup = null, // numero di transazione restituito in fase di pagamento
                    Numero = "",
                    Righe = new dcOrdineRiga[]
                    {
                        new dcOrdineRiga()
                        {
                            IdListino = new IdBox()
                            {
                                Id = "130301020200724569922010014585",
                                IdEsterno = ""
                            },
                            // IdOperatore = new IdBox()
                            // {
                            //     Id = "",
                            //     IdEsterno = ""
                            // },
                            // IdPostazione = new IdBox()
                            // {
                            //     Id = "",
                            //     IdEsterno = ""
                            // },
                            // IdReservation = "RSV000120220608589636410000062",
                            IdTariffa = new IdBox()
                            {
                                Id = "130301020200102374347270001412",
                                IdEsterno = ""
                            },
                            IdTariffaListino = new IdBox()
                            {
                                Id = "130301020200724585095230097277",
                                IdEsterno = ""
                            },
                            Impianto = "1303",
                            Importo = 50,
                            IsRegalo = false,
                            NominativoRegalo = "",
                            Quantita = 1,
                            Componenti = new dcOrdineRigaComponente[]
                            {
                                new dcOrdineRigaComponente()
                                {
                                    
                                }
                            }
                        }
                        // ,
                        // new dcOrdineRiga()
                        // {
                        //     IdListino = new IdBox()
                        //     {
                        //         Id = "130300420171025446902520026349"
                        //     },
                        //     IdTariffa = new IdBox()
                        //     {
                        //         Id = "130301020200102374347270001412",
                        //         IdEsterno = ""
                        //     },
                        //     IdTariffaListino = new IdBox()
                        //     {
                        //         Id = "130301020200102378203280007602",
                        //         IdEsterno = ""
                        //     },
                        //     Impianto = "1303",
                        //     Importo = 40,
                        //     IsRegalo = false,
                        //     NominativoRegalo = "",
                        //     Quantita = 1
                        // }
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

            var esito = await commerceClient.AcquistaIscrizioneAsync(baseRequest,
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

            var esito = await commerceClient.AcquistaSospesiAsync(baseRequest,
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

            var esito = await commerceClient.FruisciAsync(baseRequest,
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

            var esito = await commerceClient.GetNexiConfigAsync(baseRequest);

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

            var esito = await commerceClient.GetPayPalIdAsync(baseRequest);

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

            var esito = await commerceClient.SetNexiConfigAsync(baseRequest,
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

            var esito = await commerceClient.SetVoucherAsGiftAsync(baseRequest,
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

            var esito = await commerceClient.SetVoucherUserAsync(baseRequest,
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

            var esito = await commerceClient.TestAcquistaIscrizioneAsync(baseRequest,
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

            var esito = await commerceClient.TestCartAsync(baseRequest,
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
