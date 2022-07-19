using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using wsListini;

namespace AquardensNUnitTest.Listini
{
    public class iElenchi_003 : Base001
    {
        protected iElenchi_003Client elenchiClient = new iElenchi_003Client();

        [Test]
        public async Task GetListini()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = "1303",
                // SessionId = "9ff2ea57-22e4-4618-b1eb-b7788130c9fb"

                SessionId = SessionId
                // SessionId = "990f86a0-c553-451b-af39-045ff63832d1"
            };

            var esito = await elenchiClient.GetListiniAsync(baseRequest,
                 new dcListinoFilter()
                 // {
                    // IdListino = new IdBox()
                    // {
                    //     Id = "130300420171025466098820032293"
                    // }
                    // Data = System.DateTime.Now,
                    // DatiAggiuntivi = true, // immagine e testo aggiuntivo
                    // IdTariffe = new IdBox[]
                    // {
                    //     new IdBox()
                    //     {
                    //       //Id = "",
                    //       IdEsterno = "lst"
                    //     },
                    //     new IdBox()
                    //     {
                    //         // Id = "130301020200102462710870081334"
                    //         IdEsterno = "sconto_10"
                    //     }
                    // },
                    // IsGiornoFestivo = true,
                    // TariffaRichiesta = 1, // discriminante per farsi dare le tariffe richieste (0 = default)
                    // TipiListini = new int[] { },
                    // TipoPagamentoPrenotazione = 0,
                    // Utenza = ""
                 // }
            );

            TestContext.WriteLine($"Loaded {esito.Elenco.Length} items.");
            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
