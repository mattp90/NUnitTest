using System.Threading.Tasks;
using NUnit.Framework;
using AquardensNUnitTest;
using AquardensDatabase.Entity;

namespace wsListini
{
    public partial class Elenchi : Base
    {
        protected iElenchiClient Client = new iElenchiClient();

        [Test]
        public async Task GetCategorie()
        {
            var esito = await Client.GetCategorieAsync(SessionId, Impianto, 1);
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [Test]
        public async Task GetListini()
        {
            var esito = await Client.GetListiniAsync(SessionId, Impianto);
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [Test]
        public async Task GetListiniFilterd()
        {
            var esito = await Client.GetListiniFilteredAsync(SessionId, Impianto, new dcListinoFilter()
            {
                IdListino = new IdBox()
                {
                    Id = "130300420171025439855100025227"
                }
                // TipiListini = new int[] { 6, 7 },
                // IdCategoria = "130301020200511569852290001414"
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
    
    public class Gestione : Base
    {
        protected iGestioneClient Client = new iGestioneClient();
        
        [Test]
        public async Task  AddListini()
        {
            var esito = await Client.AddListiniAsync(SessionId, Impianto, new[] { new dcListino() });
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