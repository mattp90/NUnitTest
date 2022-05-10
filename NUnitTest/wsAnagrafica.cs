using AquardensNUnitTest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AquardensDatabase.Entity;

namespace wsAnagrafica
{
    public partial class Elenchi : Base
    {
        protected iElenchiClient ElenchiClient = new iElenchiClient();

        [Test]
        public async Task GetAnagrafiche()
        {
            var esito = await ElenchiClient.GetAnagraficheAsync(SessionId, Impianto, new dcAnagraficaFilter()
                {
                    // Pagina = 1,
                    // NumeroMaxAnagrafiche = 10,
                    Nome = "aquest",
                    // Cognome = "Aquardens",
                    // Cognome = "Test",
                    // IdAnagrafica = new IdBox()
                    // {
                    //     Id = "ACC000120220118515832160000008"
                    // }
                }
            );

            Print($"Caricati {esito.Elenco.Length} elementi.");
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [Test]
        public async Task GetIscrizioni()
        {
            var anagrafica = new IdBox()
            {
                Id = "130300820180921490461560021204"
            };

            var esito = await ElenchiClient.GetIscrizioniAsync(SessionId, Impianto, anagrafica, true);
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [OneTimeTearDown]
        public void TearDownClient()
        {
            ElenchiClient.Close();
        }
    }
    
    public class Gestione : Base
    {
        protected iGestioneClient Client = new iGestioneClient();
        protected iElenchiClient ElenchiClient = new iElenchiClient();
        
        [Test]
        public async Task Aggiungi()
        {
            var anagrafica = new dcAnagraficaCompleta()
            {
                Cellulare = "123456789",
                Cognome = "aquest",
                Email = "roberto.sartori@aquest.it",
                Impianto = "1303",
                Nome = "Roberto",
                Nota = "Test Nota",
                Sesso = "M",
                Telefono = "123456789",
                Username = "robertosartori2022",
                Password = "Password2022!",
                IsAzienda = false,
                IsPersonaFisica = true,
                DataNascita = new DateTime(1990, 01, 01)
            };
            var esito = await Client.AggiungiAsync(SessionId, Impianto, anagrafica);
            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [Test]
        public async Task Modifica()
        {
            var anagrafica = ElenchiClient.GetAnagraficheAsync(SessionId, Impianto, new dcAnagraficaFilter()
            {
                IdAnagrafica = new IdBox()
                {
                    Id = "ANA000120220503515542470000007"
                } 
            }).Result.Elenco.First();
            
            anagrafica.Cellulare = "123456789";
            anagrafica.Cognome = "Sartori";
            anagrafica.RagioneSociale = "Ragione sociale";
            anagrafica.IsPersonaFisica = true;
            anagrafica.Username = "r.sartori";
            anagrafica.Password = "Password2022";
            
            var esito = await Client.ModificaAsync(SessionId, Impianto, anagrafica);
            Print(esito);
            Assert.IsTrue(esito.EsitoCodice == 0);
        }
        
        [OneTimeTearDown]
        public void TearDownClient()
        {
            Client.Close();
            ElenchiClient.Close();
        }
    }
}