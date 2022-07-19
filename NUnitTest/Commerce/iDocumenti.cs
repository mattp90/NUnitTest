using NUnit.Framework;
using System.Threading.Tasks;
using wsCommerce;

namespace AquardensNUnitTest.Commerce
{
    public class iDocumenti : Base001
    {
        protected iDocumentiClient documentiClient = new iDocumentiClient();

        [Test]
        public async Task GetDocumenti()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await documentiClient.GetDocumentiAsync(baseRequest,
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
        public async Task GetDocumentiXml()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await documentiClient.GetDocumentiXmlAsync(baseRequest,
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

            var esito = await documentiClient.SetAcquisitiAsync(baseRequest,
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
