using System;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using wsAnagrafica;

namespace AquardensNUnitTest.Anagrafica
{
    public class AnagraficaGestione : Base
    {
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
            
            var esito = await GestioneAnagraficaClient.AggiungiAsync(baseRequest, anagrafica);
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
            
            var anagrafica = ElenchiAnagraficaClient.GetAnagraficheAsync(baseRequest, new dcAnagraficaFilter()
            {
                IdAnagrafica = new IdBox()
                {
                    Id = "ACC000120220922365008200000004"
                } 
            }).Result.Elenco.First();

            
            // anagrafica.Nome = "Matteo";
            // anagrafica.Cognome = "A";
            // anagrafica.Cellulare = "123456789";
            // anagrafica.RagioneSociale = "Ragione sociale";            
            // anagrafica.Impianto = "1303";
            // anagrafica.CellularePrefissoInt = "39";
            // anagrafica.CodiceDestinatario = "";
            // anagrafica.CodiceFiscale = "PZZMTT90S10M172Z";
            // anagrafica.CodiceLotteria = "";
            // anagrafica.IsAzienda = false;
            // anagrafica.IsPersonaFisica = true;
            // anagrafica.Nota = "nota nota nota";
            // anagrafica.NotaBreve = "nota breve";
            // anagrafica.PartitaIva = "";
            // anagrafica.Privacy = true;
            // anagrafica.Sesso = "M";            
            // anagrafica.Telefono = "";

            anagrafica.IndirizzoPredefinito = new dcAnagraficaIndirizzo()
            {
                Cap = "37100",
                Frazione = "",
                Indirizzo = "Via G. Verdi",
                Localita = "San Giovanni Lupatoto",
                Provincia = "VR",
                IsPredefinito = true
            };
            anagrafica.CodiceFiscale = "MRCMRC90S10M172Z";

            var esito = await GestioneAnagraficaClient.ModificaAsync(baseRequest, anagrafica);
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
            
            var esito = await GestioneAnagraficaClient.SetUserNoteAsync(baseRequest, new dcNoteRequest()
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
            
            var esito = await GestioneAnagraficaClient.UploadUserFileAsync(baseRequest, new dcFileRequest()
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
    }
}
