using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using wsListini;

namespace AquardensNUnitTest.Listini
{
    public class iElenchi_002 : Base001
    {
        protected iElenchi_002Client elenchiClient = new iElenchi_002Client();

        [Test]
        public async Task GetCategorie()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await elenchiClient.GetCategorieAsync(baseRequest,
                new dcCategoriaFilter()
                {
                    DatiAggiuntivi = false,
                    Tipo = 2
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetComponentiPacchetto()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await elenchiClient.GetComponentiPacchettoAsync(baseRequest, 
                new dcComponentiPacchettoRequest()
                {
                    DatiAggiuntivi = false,
                    IdPacchetto = new IdBox()
                    {
                        Id = "",
                        IdEsterno = ""
                    }
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetListini()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = "9ff2ea57-22e4-4618-b1eb-b7788130c9fb"

                // SessionId = SessionId
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

        [Test]
        public async Task GetListiniPrenotabili()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                // SessionId = SessionId
                SessionId = "45614cea-c9e7-4d8a-9fc4-7b56795dc1ba"
            };

            var esito = await elenchiClient.GetListiniAsync(baseRequest, null);
            esito.Elenco = esito.Elenco.ToList().Where(x => x.IsPrenotabile.HasValue && x.IsPrenotabile.Value).ToArray();

            TestContext.WriteLine($"Loaded {esito.Elenco.Length} items.");
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [Test]
        public async Task GetListiniNonPrenotabili()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                // SessionId = SessionId
                SessionId = "990f86a0-c553-451b-af39-045ff63832d1"
            };

            var esito = await elenchiClient.GetListiniAsync(baseRequest, null);
            esito.Elenco = esito.Elenco.ToList().Where(x => x.IsPrenotabile.HasValue && !x.IsPrenotabile.Value).ToArray();
            
            TestContext.WriteLine($"Loaded {esito.Elenco.Length} items.");
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetListiniProdotti()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                // SessionId = SessionId
                SessionId = "990f86a0-c553-451b-af39-045ff63832d1"
            };

            var esito = await elenchiClient.GetListiniAsync(baseRequest,
                new dcListinoFilter()
                {                
                    TipiListini = new int[] { 5 },
                }
            );

            TestContext.WriteLine($"Loaded {esito.Elenco.Length} items.");
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetListiniTrattamenti()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                // SessionId = SessionId
                SessionId = "990f86a0-c553-451b-af39-045ff63832d1"
            };

            var esito = await elenchiClient.GetListiniAsync(baseRequest,
                new dcListinoFilter()
                {
                    TipiListini = new int[] { 6 },
                }
            );

            TestContext.WriteLine($"Loaded {esito.Elenco.Length} items.");
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetListiniPacchetti()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                // SessionId = SessionId
                SessionId = "990f86a0-c553-451b-af39-045ff63832d1"
            };

            var esito = await elenchiClient.GetListiniAsync(baseRequest,
                new dcListinoFilter()
                {
                    TipiListini = new int[] { 7 },
                }
            );

            TestContext.WriteLine($"Loaded {esito.Elenco.Length} items.");
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetListiniRicariche()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                // SessionId = SessionId
                SessionId = "990f86a0-c553-451b-af39-045ff63832d1"
            };

            var esito = await elenchiClient.GetListiniAsync(baseRequest,
                new dcListinoFilter()
                {
                    TipiListini = new int[] { 4 },
                }
            );

            TestContext.WriteLine($"Loaded {esito.Elenco.Length} items.");
            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetListiniCompatibiliRinnovo()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await elenchiClient.GetListiniCompatibiliRinnovoAsync(baseRequest,
                0, // Tipi Listino
                "" // Id Iscrizione
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
