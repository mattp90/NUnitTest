using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using wsListini;

namespace AquardensNUnitTest.Listini
{
    public class ListiniElenchi : Base
    {
        [Test]
        public async Task GetCategorie()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await ElenchiListiniClient.GetCategorieAsync(baseRequest,
                new dcCategoriaFilter()
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetCategorieListini()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var categorie = await ElenchiListiniClient.GetCategorieAsync(baseRequest, new dcCategoriaFilter());

            var listiniProcessati = new List<dcListino>();
            
            foreach (var c in categorie.Elenco.OrderBy(x => x.Descrizione))
            {
                // TestContext.WriteLine($"{Environment.NewLine}");
                TestContext.WriteLine($"Categoria {c.Descrizione}"); 
                var listini = await ElenchiListini003Client.GetListiniAsync(baseRequest,
                    new dcListinoFilter()
                    {
                        IdCategoria = c.Id.Id    
                    }
                );

                listiniProcessati.AddRange(listini.Elenco.ToList());
                    
                foreach (var l in listini.Elenco.OrderBy(x => x.Descrizione))
                {
                    // TestContext.WriteLine($"\t{l.Descrizione} - {l.Id.Id} - {l.Id.IdEsterno}");
                    TestContext.WriteLine($"\t{l.Descrizione} - {l.Id.Id} - {l.Id.IdEsterno}");
                }
            }
            
            TestContext.WriteLine($"Prodotti senza categoria");
            var listiniAll = await ElenchiListini003Client.GetListiniAsync(baseRequest, new dcListinoFilter());
            foreach (var listino in listiniAll.Elenco.OrderBy(x => x.Descrizione))
            {
                if (!listiniProcessati.Any(x => x.Id.Id.Contains(listino.Id.Id)))
                {
                    TestContext.WriteLine($"\t{listino.Descrizione} - {listino.Id.Id} - {listino.Id.IdEsterno}");
                }
            }
            
            Assert.IsNotNull(categorie);
        }
        
        [Test]
        public async Task GetListiniWithNoCategory()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var categorie = await ElenchiListiniClient.GetCategorieAsync(baseRequest, new dcCategoriaFilter());

            var listiniProcessati = new List<dcListino>();
            
            foreach (var c in categorie.Elenco.OrderBy(x => x.Descrizione))
            {
                // TestContext.WriteLine($"{Environment.NewLine}");
                var listini = await ElenchiListini003Client.GetListiniAsync(baseRequest,
                    new dcListinoFilter()
                    {
                        DatiAggiuntivi = true,
                        IdCategoria = ""    
                    }
                );

                listiniProcessati.AddRange(listini.Elenco.ToList());
                    
                foreach (var l in listini.Elenco.OrderBy(x => x.Descrizione))
                {
                    // TestContext.WriteLine($"\t{l.Descrizione} - {l.Id.Id} - {l.Id.IdEsterno}");
                    TestContext.WriteLine($"{l.Descrizione} - {l.Id.Id} - {l.Id.IdEsterno} - {l.ComponenteInfo?.Categoria?.Descrizione}");
                }
            }
            
            Assert.IsNotNull(categorie);
        }
        
        [Test]
        public async Task GetComponentiPacchetto()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await ElenchiListiniClient.GetComponentiPacchettoAsync(baseRequest, 
                new dcComponentiPacchettoRequest()
                {
                    IdPacchetto = new IdBox()
                    {
                        Id = "130301020220805616258110016842"
                    },
                    IdTariffaListino = new IdBox()
                    {
                        Id = "130301020220805617366060016953"
                    }
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task PrepareExcel()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var categories = await ElenchiListiniClient.GetCategorieAsync(baseRequest,
                new dcCategoriaFilter()
                {
                    DatiAggiuntivi = false
                }
            );

            var listiniConCategoria = new List<dcListino>();
            var listiniSenzaCategoria = new List<dcListino>();
            
            foreach (var c in categories.Elenco)
            {
                var listini = await ElenchiListini003Client.GetListiniAsync(baseRequest,
                    new dcListinoFilter()
                    {
                        IdCategoria = c.Id.Id 
                    }
                );

                foreach (var listino in listini.Elenco)
                {
                    listiniConCategoria.Add(listino);
                    Print($"{listino.Descrizione};{listino.Id.Id};{c.Descrizione};{c.Id.Id};{listino.Tariffe.First().Importo};{listino.Tariffe.First().IdTariffaListino.Id}");
                }
            }
            
            var listiniAll = await ElenchiListini003Client.GetListiniAsync(baseRequest,
                new dcListinoFilter()
            );

            foreach (var l in listiniAll.Elenco)
            {
                if (!listiniConCategoria.Any(x => x.Descrizione == l.Descrizione))
                {
                    listiniSenzaCategoria.Add(l);
                    Print($"{l.Descrizione};{l.Id.Id};;;{l.Tariffe.First().Importo};{l.Tariffe.First().IdTariffaListino.Id}");
                }
            }
            
            Assert.IsNotNull(categories);
        }
        
        [Test]
        public async Task GetListini()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
                // SessionId = "990f86a0-c553-451b-af39-045ff63832d1"
            };

            var esito = await ElenchiListini003Client.GetListiniAsync(baseRequest,
                 new dcListinoFilter()
                 // { IdListino = new IdBox() { Id = "130300420171025443104150025354" } }
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

            // foreach (var listino in esito.Elenco)
            // {
            //     var isPrenot = listino.IsPrenotabile.HasValue ? listino.IsPrenotabile.Value : false;
            //     TestContext.WriteLine($"update product set Sku = '{listino.Id.Id}', ManufacturerPartNumber = '{listino.Id.IdEsterno}', IsTelecommunicationsOrBroadcastingOrElectronicServices = " +
            //                           $"{isPrenot.ToString()} where Name = '{listino.Descrizione}' and Published;");    
            // }
            
            TestContext.WriteLine($"Loaded {esito.Elenco.Length} items.");
            esito.Elenco = esito.Elenco.OrderBy(x => x.Descrizione).ToArray();
            
            Print(esito.Elenco.Select(x => new
            {
                Descrizione = x.Descrizione,
                Id = x.Id.Id,
                IdEsterno = x.Id.IdEsterno,
                Prenotabile = x.IsPrenotabile ?? false,
                VenditaSingola = x.IsSingleSale ?? false,
                Iva = x.Iva != null ? x.Iva.Descrizione : "",
                IdTariffa = x.Tariffe[0].Id.Id,
                IdTariffaListino = x.Tariffe[0].IdTariffaListino.Id,
                Importo = x.Tariffe[0].Importo
            }).ToList());
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetListiniPrenotabili()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await ElenchiListiniClient.GetListiniAsync(baseRequest, null);
            esito.Elenco = esito.Elenco.ToList().Where(x => x.IsPrenotabile.HasValue && x.IsPrenotabile.Value).ToArray();

            var ids = esito.Elenco.Select(x => x.Id.Id).ToList();
            
            TestContext.WriteLine($"Loaded {esito.Elenco.Length} items.");

            foreach (var listino in esito.Elenco)
            {
                if (listino.IsPrenotabile.HasValue && listino.IsPrenotabile.Value)
                {
                    TestContext.WriteLine($"\t{listino.Descrizione} - {listino.Id.Id} - {listino.Id.IdEsterno}.");
                }
            }
            
            // Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [Test]
        public async Task GetListiniNonPrenotabili()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await ElenchiListiniClient.GetListiniAsync(baseRequest, null);
            esito.Elenco = esito.Elenco.OrderBy(x => x.Descrizione).ToArray();
            // esito.Elenco = esito.Elenco.ToList().Where(x => x.IsPrenotabile.HasValue && !x.IsPrenotabile.Value).ToArray();
            
            TestContext.WriteLine($"Loaded {esito.Elenco.Length} items.");
            foreach (var listino in esito.Elenco)
            {
                if(listino.IsPrenotabile == null || !listino.IsPrenotabile.Value)
                    TestContext.WriteLine($"{listino.Descrizione}");
            }
            // Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task GetListiniProdotti()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await ElenchiListiniClient.GetListiniAsync(baseRequest,
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
                SessionId = SessionId
            };

            var esito = await ElenchiListiniClient.GetListiniAsync(baseRequest,
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
                SessionId = SessionId
            };

            var esito = await ElenchiListiniClient.GetListiniAsync(baseRequest,
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
                SessionId = SessionId
            };

            var esito = await ElenchiListiniClient.GetListiniAsync(baseRequest,
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

            var esito = await ElenchiListiniClient.GetListiniCompatibiliRinnovoAsync(baseRequest,
                0, // Tipi Listino
                "" // Id Iscrizione
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}
