using System;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using wsAnagrafica;

namespace AquardensNUnitTest_2.Anagrafica
{
    public class iGestione_001 : Base001
    {
        protected iElenchi_001Client anagraficaElenchiClient = new iElenchi_001Client();
        protected iGestione_001Client anagraficaClient = new iGestione_001Client();

        [Test]
        public async Task Aggiungi()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var anagrafica = new dcAnagraficaCompleta()
            {
                Nome = "Luca",
                Cognome = "Luchi",
                Email = "luca.luchi@test.com",
                Impianto = "1303",
                DataNascita = new DateTime(1990, 01, 01),
                // Cellulare = "123456789",
                Nota = "Test Nota",
                Sesso = "M",
                // Telefono = "123456789",
                Username = "luca.luchi@test.com",
                IsAzienda = false,
                IsPersonaFisica = true,
            };
            
            var esito = await anagraficaClient.AggiungiAsync(baseRequest, anagrafica);
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [Test]
        public async Task Modifica()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };
            
            var anagrafica = anagraficaElenchiClient.GetAnagraficheAsync(baseRequest, new dcAnagraficaFilter()
            {
                IdAnagrafica = new IdBox()
                {
                    Id = "ACC000120220607450005030000042"
                } 
            }).Result.Elenco.First();
                        
            anagrafica.Nome = "Matteo";
            anagrafica.Cognome = "A";
            anagrafica.Cellulare = "123456789";
            anagrafica.RagioneSociale = "Ragione sociale";            
            anagrafica.Impianto = "1303";
            anagrafica.CellularePrefissoInt = "39";
            anagrafica.CodiceDestinatario = "";
            anagrafica.CodiceFiscale = "PZZMTT90S10M172Z";
            anagrafica.CodiceLotteria = "";
            anagrafica.IsAzienda = false;
            anagrafica.IsPersonaFisica = true;
            anagrafica.Nota = "nota nota nota";
            anagrafica.NotaBreve = "nota breve";
            anagrafica.PartitaIva = "";
            anagrafica.Privacy = true;
            anagrafica.Sesso = "M";            
            anagrafica.Telefono = "";

            var esito = await anagraficaClient.ModificaAsync(baseRequest, anagrafica);
            Print(esito);
            Assert.IsTrue(esito.EsitoCodice == 0);
        }

        [Test]
        public async Task SetUserNote()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };
            
            var esito = await anagraficaClient.SetUserNoteAsync(baseRequest, new dcNoteRequest()
            {
                Append = true,
                Note = "prova note test",
                IdUser = new IdBox()
                {
                    Id = "ANA000120220415570028060000037" 
                } 
            });
            Print(esito);
            Assert.IsTrue(esito.EsitoCodice == 0);
        }

        [Test]
        public async Task UploadUserFile()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };
            
            var esito = await anagraficaClient.UploadUserFileAsync(baseRequest, new dcFileRequest()
            {
                Description = "File test for user",
                File = null,
                FileName = "test.txt",
                IdUser = new IdBox()
                {
                    Id = "ANA000120220415570028060000037" 
                }
            });
            Print(esito);
            Assert.IsTrue(esito.EsitoCodice == 0);
        }
        
        [OneTimeTearDown]
        public void TearDownClient()
        {
            anagraficaClient.Close();
            anagraficaElenchiClient.Close();
        }
    }
}
