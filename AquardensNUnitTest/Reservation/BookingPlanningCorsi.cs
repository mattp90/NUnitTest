using NUnit.Framework;
using System.Threading.Tasks;
using wsReservation;

namespace AquardensNUnitTest.Reservation
{
    public class BookingPlanningCorsi : Base
    {
        [Test]
        public async Task RecuperiConta()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await BookingPlanningCorsiClient.RecuperiContaAsync(baseRequest,
                new IdBox() // Id Iscrizione
                {
                    Id = "",
                    IdEsterno = ""
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task RecuperiGetItems()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await BookingPlanningCorsiClient.RecuperiGetItemsAsync(baseRequest,
                new dcPlanningRecuperiItemFilter()
                {
                    DataOraFine = null,
                    DataOraInizio = null,
                    IdIscrizione = "",
                    MaxResults = null
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }

        [Test]
        public async Task RecuperiInsert()
        {
            var baseRequest = new dcBaseRequest()
            {
                Impianto = Impianto,
                SessionId = SessionId
            };

            var esito = await BookingPlanningCorsiClient.RecuperiInsertAsync(baseRequest,
                new dcReservation()
                {
                    Anagrafica = new InfoBox()
                    {
                        Descrizione = "",
                        Id = "",
                        IdEsterno = ""
                    },
                    DataOraFine = null,
                    DataOraInizio = null,
                    Fila = null,
                    HotelPrenotazione = new dcHotelPrenotazione()
                    {
                        DataFine = System.DateTime.MinValue,
                        DataInizio = System.DateTime.MinValue,
                        Email = "",
                        Id = new IdBox()
                        {
                            Id = "",
                            IdEsterno = ""
                        },
                        IdHotel = new IdBox()
                        {

                        },
                        IdReservation = new IdBox()
                        {
                            Id = "",
                            IdEsterno = ""
                        },
                        Impianto = "",
                        Nominativo = "",
                        NrPersone = null,
                        NumeroCamera = "",
                        Telefono = "",
                        TipoPrenotazione = null
                    },
                    IdIscrizione = new IdBox()
                    {
                        Id = "",
                        IdEsterno = ""
                    },
                    IdOrario = new IdBox()
                    {
                        Id = "",
                        IdEsterno = ""
                    },
                    IdReservation = new IdBox()
                    {
                        Id = "",
                        IdEsterno = ""
                    },
                    IngResiduiIscriz = null,
                    IsFruito = null,
                    Item = new InfoBox()
                    {
                        Descrizione = "",
                        Id = "",
                        IdEsterno = ""
                    },
                    ItemPrenotStatus = null,
                    Livello = new InfoBox()
                    {
                        Descrizione = "",
                        Id = "",
                        IdEsterno = ""
                    },
                    Mappa = new InfoBox()
                    {
                        Descrizione = "",
                        Id = "",
                        IdEsterno = ""
                    },
                    Nota = "",
                    NotaPrescrizione = "",
                    NotaTrattamento = "",
                    NumPiaz = "",
                    Personale = new InfoBox()
                    {
                        Descrizione = "",
                        Id = "",
                        IdEsterno = ""
                    },
                    Posti = null,
                    PostiOccupati = null,
                    Riga = null,
                    Spazio = new InfoBox()
                    {
                        Descrizione = "",
                        Id = "",
                        IdEsterno = ""
                    },
                    Status = null,
                    Telefono = "",
                    Tipo = null,
                    TipoConferma = null
                }
            );

            Print(esito);
            Assert.IsNotNull(esito);
        }
    }
}