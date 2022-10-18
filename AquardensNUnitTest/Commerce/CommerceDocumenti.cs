using System;
using NUnit.Framework;
using System.Threading.Tasks;
using wsCommerce;

namespace AquardensNUnitTest.Commerce
{
    public class CommerceDocumenti : Base
    {
        [Test]
        public async Task GetDocumenti()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId,
                ClientId = "a9760d7d-0fc4-45d5-bf04-271afe567bb0"
            };

            var esito = await DocumentClient.GetDocumentiAsync(baseRequest,
                new dcDocumentoFilter()
                {
                    DaData = new DateTime(2022, 10, 11, 0,0,0),
                    AData = new DateTime(2022, 10, 13, 0,0,0),
                    DocumentiAnagObbligatoria = new string[] { },
                    IdAnagrafica = new IdBox()
                    { 
                        Id = "ACC000120221006646461880000077",
                        IdEsterno = ""
                    },
                    Impianto = "1303",
                    NonAcquisiti = null,
                    TipiDocumento = new string[] { }
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetDocumentiXml()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await DocumentClient.GetDocumentiXmlAsync(baseRequest,
                new dcDocumentoFilter()
                {
                    AData = null,
                    DaData = null,
                    DocumentiAnagObbligatoria = new string[] { },
                    IdAnagrafica = new IdBox()
                    {
                        Id = "",
                        IdEsterno = ""
                    },
                    IdGruppoFatturazione = new IdBox()
                    {
                        Id = "",
                        IdEsterno = ""
                    },
                    IdRagioneSociale = new IdBox()
                    {
                        Id = "",
                        IdEsterno = ""
                    },
                    Impianto = "",
                    NonAcquisiti = null,
                    TipiDocumento = new string[] { }
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task SetAcquisiti()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await DocumentClient.SetAcquisitiAsync(baseRequest,
                new IdBox[]
                {
                    new IdBox()
                    {
                        Id = "",
                        IdEsterno = ""
                    }
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
