using System;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using wsAnagrafica;

namespace AquardensNUnitTest_2.Anagrafica
{
    public class iElenchi_001 : Base001
    {
        protected iElenchi_001Client anagraficaClient = new iElenchi_001Client();

        [Test]
        public async Task GetAnagrafiche()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await anagraficaClient.GetAnagraficheAsync(baseRequest,
                new dcAnagraficaFilter()
                {
                    Nome = "User",
                    Cognome = "Test"
                    // UserName = "marco.marchi@test.com"
                });

            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [Test]
        public async Task GetIscrizioni()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };
            
            var esito = await anagraficaClient.GetIscrizioniAsync(baseRequest, new IdBox(), true);
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetMemberCard()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };
            
            var esito = await anagraficaClient.GetMemberCardAsync(baseRequest, new dcMemberCardFilter()
            {
                AllCards = true
            });
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetPagamentiSospesi()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };
            
            var esito = await anagraficaClient.GetPagamentiSospesiAsync(baseRequest, new dcPagamentoSospesoFilter()
            {
                DataDal = DateTime.MinValue,
                DataAl = DateTime.MaxValue
            });
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [OneTimeTearDown]
        public void TearDownClient()
        {
            anagraficaClient.Close();
        }
    }
}
