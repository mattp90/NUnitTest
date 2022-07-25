using AquardensNUnitTest;
using NUnit.Framework;
using System.Threading.Tasks;

namespace wsCommerce
{
    public class Report002 : Base001
    {
        protected iReport_001Client ReportClient = new iReport_001Client();
        
        [Test]
        public async Task GetAquisti()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await ReportClient.GetAcquistiAsync(baseRequest, new dcAcquistoFilter()
            {
                TipoAcqusto = 0,
                IdAnagrafica = new IdBox()
                {
                    Id = "130300820180907371532370002171"
                }
            });
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [OneTimeTearDown]
        public void TearDownClient()
        {
            ReportClient.Close();
        }    
    }
}