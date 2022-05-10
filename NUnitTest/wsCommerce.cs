using System;
using AquardensNUnitTest;
using NUnit.Framework;
using System.Threading.Tasks;

namespace wsCommerce
{
    public class Commerce: Base
    {
        protected iCommerceClient CommerceClient = new iCommerceClient();

        [Test]
        public async Task  Acquista()
        {
            var ordine = new dcOrdineAcquisto()
            {
                Numero = null,
                Righe = new dcOrdineRiga[]
                {
                    new dcOrdineRiga()
                    {
                        Impianto = Impianto,
                        Importo = 0,
                        Quantita = 1,
                        IdListino = new IdBox()
                        {
                            Id = "130300420171025443104150025354"
                        },
                        IdOperatore = null,
                        IdPostazione = null,
                        IdReservation = null,
                        IdTariffa = new IdBox()
                        {
                            Id = "130301020200102374347270001412"
                        },
                        IsRegalo = false,
                        NominativoRegalo = "pippo baudo",
                        IdTariffaListino = new IdBox()
                        {
                            Id = "130301020200102383827230017802"
                        }
                    }
                },
                ControllaCup = null,
                TipoDocumento = null
            };

            var esito = await CommerceClient.AcquistaAsync(SessionId, Impianto, ordine);
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [Test]
        public async Task  GetPayPalId()
        {
            var esito = await CommerceClient.GetPayPalIdAsync(SessionId, Impianto);
            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
    
    public class Documenti : Base
    {
        protected iDocumentiClient Client = new iDocumentiClient();
        
        [Test]
        public async Task  GetDocumenti()
        {
            var esito = await Client.GetDocumentiAsync(new dcBaseRequest()
                {
                    Impianto = Impianto, 
                    SessionId = SessionId
                }, 
                new dcDocumentoFilter()
                {
                    Impianto = Impianto,
                    IdAnagrafica = new IdBox()
                    {
                        Id = "ACC000120220504600072070000064"
                    }
                }
            );
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [Test]
        public async Task  GetDocumentiXml()
        {
            var esito = await Client.GetDocumentiXmlAsync(new dcBaseRequest()
                {
                    Impianto = Impianto, 
                    SessionId = SessionId
                }, 
                new dcDocumentoFilter()
                {
                    Impianto = Impianto,
                    IdAnagrafica = new IdBox()
                    {
                        Id = "ANA000120220415570028060000037"
                    }
                }
            );
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [Test]
        public async Task  SetAcquisiti()
        {
            var esito = await Client.SetAcquisitiAsync(new dcBaseRequest()
                {
                    Impianto = Impianto, 
                    SessionId = SessionId
                }, 
                new []{ new IdBox() }
            );
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [OneTimeTearDown]
        public void TearDownClient()
        {
            Client.Close();
        }
    }

    public class FirmaDigitale : Base
    {
        protected iFirmaDigitaleClient Client = new iFirmaDigitaleClient();

        [Test]
        public async Task GetSelfSignTexts()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };
            var esito = await Client.GetSelfSignTextsAsync(baseRequest, new dcSelfSignTextFilter()
            {
                DataDal = DateTime.MinValue,
                DataAl = DateTime.MaxValue
            });
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [Test]
        public async Task SetSelfSignText()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };
            var esito = await Client.SetSelfSignTextAsync(baseRequest, new dcSelfSignText());
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [OneTimeTearDown]
        public void TearDownClient()
        {
            Client.Close();
        }
    }

    public class Report : Base
    {
        protected iReportClient Client = new iReportClient();
        
        [Test]
        public async Task  VoucherList()
        {
            var esito = await Client.VoucherListAsync(SessionId, Impianto, new dcReportFilter());
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [Test]
        public async Task  VoucherDetail()
        {
            var esito = await Client.VoucherDetailAsync(SessionId, Impianto, new dcVoucherDetailRequest()
            {
                CodiceVoucher = new IdBox()
                {
                    Id = ""
                }
            });
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [OneTimeTearDown]
        public void TearDownClient()
        {
            Client.Close();
        }
    }
}