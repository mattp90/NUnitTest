using System;
using NUnit.Framework;
using System.Threading.Tasks;
using wsAnagrafica;

namespace AquardensNUnitTest.Anagrafica
{
    public class AnagraficaElenchi : Base
    {
        [Test]
        public async Task GetAnagrafiche()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await ElenchiAnagraficaClient.GetAnagraficheAsync(baseRequest,
                new dcAnagraficaFilter()
                // {
                //     // UserName = "gigi.buffon@test.com",
                //     IdAnagrafica = new IdBox()
                //     {
                //         Id = "ACC000120220818791503430000006"
                //     }
                // }
             );

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
            
            var esito = await ElenchiAnagraficaClient.GetIscrizioniAsync(baseRequest, new IdBox(), true);
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
            
            var esito = await ElenchiAnagraficaClient.GetMemberCardAsync(baseRequest, new dcMemberCardFilter()
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
            
            var esito = await ElenchiAnagraficaClient.GetPagamentiSospesiAsync(baseRequest, new dcPagamentoSospesoFilter()
            {
                DataDal = DateTime.MinValue,
                DataAl = DateTime.MaxValue
            });
            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
