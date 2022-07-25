// using NUnit.Framework;
// using System.Threading.Tasks;
// using wsListini;
//
// namespace AquardensNUnitTest_2.Listini
// {
//     public class Gestione_001 : Base001
//     {
//         protected iGestione_001Client gestioneClient = new iGestione_001Client();
//
//         [Test]
//         public async Task SetListino()
//         {
//             var baseRequest = new dcBaseRequest()
//             {
//                 Impianto = Impianto,
//                 SessionId = SessionId
//             };
//
//             var esito = await gestioneClient.SetListinoAsync(baseRequest,
//                 new dcListinoCompleto()
//                 {
//                     Acconto = 0,
//                     ComponenteInfo = new dcComponenteInfo()
//                     {
//                         Categoria = new InfoBox()
//                         {
//                             Descrizione = "",
//                             Id = "",
//                             IdEsterno = ""
//                         },
//                         Quantita = 0
//                     },
//                     Costo = 0,
//                     Descrizione = "",
//                     Disponibilita = 0,
//                     Id = new IdBox()
//                     {
//                         Id = "",
//                         IdEsterno = ""
//                     },
//                     IdVoucherScadenza = "",
//                     Immagine = null,
//                     Impianto = "",
//                     IsPrenotabile = true,
//                     IsSingleSale = false,
//                     Iva = new dcIva()
//                     {
//                         Aliquota = 0,
//                         Descrizione = "",
//                         Id = "",
//                         IdEsterno = ""
//                     },
//                     Tariffa = new dcTariffa()
//                     {
//                         Descrizione = "",
//                         Id = new IdBox()
//                         {
//                             Id = "",
//                             IdEsterno = ""
//                         },
//                         IdTariffaListino = new IdBox()
//                         {
//                             Id = "",
//                             IdEsterno = ""
//                         },
//                         Importo = 0,
//                         Rate = false,
//                         ScontoAbilitato = false
//                     },
//                     TestoAggiuntivo = "",
//                     Tipo = 0
//                 }, 
//                 true // Visibile
//             );
//
//             Print(esito);
//             Assert.IsNotNull(esito);
//         }
//     }
// }
