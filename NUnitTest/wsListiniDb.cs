using System.Threading.Tasks;
using NUnit.Framework;
using AquardensNUnitTest;
using AquardensDatabase.Entity;

namespace wsListini
{
    public partial class Elenchi : Base
    {
        [Test]
        public async Task GetCategorieDb()
        {
            var esito = await Client.GetCategorieAsync(SessionId, Impianto, 1);

            using (EFContext db = new EFContext("Server=.\\SQLExpress;Database=AquardensDB;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                foreach (var categoria in esito.Elenco)
                {
                    Categoria categoriaEntity = new Categoria()
                    {
                        Id = categoria.Id.Id,
                        IdEsterno = categoria.Id.IdEsterno,
                        Descrizione = categoria.Descrizione,
                        Immagine = categoria.Immagine,
                        Impianto = categoria.Impianto,
                        Tipo = categoria.Tipo,
                        TestoAggiuntivo = categoria.TestoAggiuntivo
                    };

                    db.Categoria.Add(categoriaEntity);
                    db.SaveChanges();
                }
            }

            Print(esito);
            Assert.IsNotNull(esito);
        }
        
        [Test]
        public async Task GetListiniDb()
        {
            var esito = await Client.GetListiniAsync(SessionId, Impianto);

            using (EFContext db = new EFContext("Server=.\\SQLExpress;Database=AquardensDB;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                foreach (var listino in esito.Elenco)
                {
                    var listinoEntity = new Listino()
                    {
                        Id = listino.Id.Id,
                        IdEsterno = listino.Id.IdEsterno,
                        Acconto = listino.Acconto,
                        Costo = listino.Costo,
                        Descrizione = listino.Descrizione,
                        Disponibilita = listino.Disponibilita,
                        Immagine = listino.Immagine,
                        Impianto = listino.Impianto,
                        Tipo = listino.Tipo,
                        Iva = listino.Iva == null ? null : new Iva()
                        {
                            Descrizione = listino.Iva.Descrizione,
                            Id = listino.Iva.Id,
                            Aliquota = listino.Iva.Aliquota,
                            IdEsterno = listino.Iva.IdEsterno
                        },
                        Tariffa = listino.Tariffa == null ? null : new Tariffa()
                        {
                            Id = listino.Tariffa.Id.Id,
                            IdEsterno = listino.Tariffa.Id.IdEsterno,
                            Descrizione = listino.Tariffa.Descrizione,
                            Importo = listino.Tariffa.Importo,
                            Rate = listino.Tariffa.Rate,
                            ScontoAbilitato = listino.Tariffa.ScontoAbilitato
                        },
                        ComponenteInfo = listino.ComponenteInfo == null ? null : new ComponenteInfo()
                        {
                            Categoria = new AquardensDatabase.Entity.InfoBox()
                            {
                                Descrizione = listino.ComponenteInfo.Categoria.Descrizione
                            }
                        },
                        IsPrenotabile = listino.IsPrenotabile,
                        TestoAggiuntivo = listino.TestoAggiuntivo,
                        IdVoucherScadenza = listino.IdVoucherScadenza,
                        IsSingleSale = listino.IsSingleSale
                    };
                    db.Listino.Add(listinoEntity);
                    db.SaveChanges();
                }
            }

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}