using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Threading.Tasks;
using AquardensDatabase.Entity;

namespace wsReservation
{
    public partial class CommonLists
    {
        [Test]
        public async Task GetReservationsDb()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            using (EFContext db = new EFContext("Server=.\\SQLExpress;Database=AquardensDB;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                var esito = await Client.GetReservationsAsync(baseRequest, new dcReservationRequest()
                    // {
                    //     IdReservation = new IdBox()
                    //     {
                    //         Id = "130300820180918550079230064052"
                    //     }
                    // }
                );

                var listReservation = new List<Reservation>();

                foreach (var reservation in esito.Elenco)
                {
                    if (!string.IsNullOrEmpty(reservation.IdReservation.Id))
                    {
                        Reservation r = new Reservation()
                        {
                            Id = reservation.IdReservation.Id,
                            Fila = reservation.Fila,
                            Nota = reservation.Nota,
                            Posti = reservation.Posti,
                            Riga = reservation.Posti,
                            Status = reservation.Status,
                            Tipo = reservation.Tipo,
                            Telefono = reservation.Telefono,
                            IdEsterno = reservation.IdReservation.IdEsterno,
                            // IdOrario = reservation.IdOrario.Id,
                            IsFruito = reservation.IsFruito,
                            NotaPrescrizione = reservation.NotaPrescrizione,
                            NotaTrattamento = reservation.NotaTrattamento,
                            NumPiaz = reservation.NumPiaz,
                            PostiOccupati = reservation.PostiOccupati,
                            TipoConferma = reservation.TipoConferma,
                            DataOraFine = reservation.DataOraFine,
                            DataOraInizio = reservation.DataOraInizio,
                            IngResiduiIscriz = reservation.IngResiduiIscriz,
                            ItemPrenotStatus = reservation.ItemPrenotStatus,
                            IdIscrizione = reservation.IdIscrizione == null ? null : reservation.IdIscrizione.Id
                        };

                        r.Anagrafica = db.Anagrafica.Where(x => x.Id == reservation.Anagrafica.Id).FirstOrDefault();
                        listReservation.Add(r);
                    }
                }

                int skip = 0;
                int take = 1000;
                while (skip < listReservation.Count)
                {
                    var listTemp = listReservation.Skip(skip).Take(take).ToList();
                    db.Reservation.AddRange(listTemp);
                    db.SaveChanges();

                    skip += take;
                }

                Print(esito);
                Assert.IsNotNull(esito);
            }
        }
    }
}