using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquardensDatabase.Entity
{
    [Table("Anagrafica")]
    public class Anagrafica
    {
        [Key]
        public string Id { get; set; }
        public string IdEsterno { get; set; }
        public string CodiceDestinatario { get; set; }
        public string CodiceFiscale { get; set; }
        public string Cognome { get; set; }
        public DateTime? DataNascita { get; set; }
        public string Impianto { get; set; }
        public bool? IsAzienda { get; set; }
        public string Nome { get; set; }
        public string PartitaIva { get; set; }
        public string RagioneSociale { get; set; }
        public string Sesso { get; set; }
        public string Cellulare { get; set; }
        public string CellularePrefissoInt { get; set; }
        public string CodiceLotteria { get; set; }
        public ComuneDiNascitaInfoBox ComuneNascita { get; set; }
        public InfoBox Convenzione { get; set; }
        public string Email { get; set; }
        public string IdUtenza { get; set; }
        public string IdUtenzaEsterno { get; set; }
        public byte[] Immagine { get; set; }
        public bool IsPersonaFisica { get; set; }
        public string Nota { get; set; }
        public string NotaBreve { get; set; }
        public string Password { get; set; }
        public bool? Privacy { get; set; }
        public string Telefono { get; set; }
        public string Username { get; set; }

        public AnagraficaIndirizzo IndirizzoPredefinito { get; set; }
        public DatiStatistici DatiStatistici { get; set; }
    }

    [Table("AnagraficaIndirizzo")]
    public class AnagraficaIndirizzo
    {
        public int Id { get; set; }
        public string Cap { get; set; }
        public string Frazione { get; set; }
        public string Indirizzo { get; set; }
        public bool? IsPredefinito { get; set; }
        public string Localita { get; set; }
        public string Provincia { get; set; }
        public int? Tipo { get; set; }
    }

    [Table("DatiStatistici")]
    public class DatiStatistici
    {
        [Key]
        public string Id { get; set; }
        public InfoBox Convenzione { get; set; }
        public DateTime? DataInserimento { get; set; }
        public InfoBox Fonte { get; set; }
        public InfoBox GruppoAnagrafica { get; set; }
        public InfoBox Professione { get; set; }
        public InfoBox StatoCivile { get; set; }
        public InfoBox TariffaPredefinita { get; set; }
        public InfoBox TipoIscritto { get; set; }
        public InfoBox TitoloStudio { get; set; }
        public InfoBox ZonaResidenza { get; set; }
    }

    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public string Id { get; set; }

        public string IdEsterno { get; set; }

        public string Descrizione { get; set; }

        public byte[] Immagine { get; set; }

        public string Impianto { get; set; }

        public string TestoAggiuntivo { get; set; }

        public int? Tipo { get; set; }
    }

    [Table("Listino")]
    public class Listino
    {
        [Key]
        public string Id { get; set; }
        public string IdEsterno { get; set; }
        public decimal? Acconto { get; set; }
        public decimal Costo { get; set; }
        public string Descrizione { get; set; }
        public int? Disponibilita { get; set; }
        public string IdVoucherScadenza { get; set; }
        public byte[] Immagine { get; set; }
        public string Impianto { get; set; }
        public bool? IsPrenotabile { get; set; }
        public bool? IsSingleSale { get; set; }
        public string TestoAggiuntivo { get; set; }
        public int Tipo { get; set; }

        public virtual ComponenteInfo ComponenteInfo { get; set; }
        public virtual Iva Iva { get; set; }
        public virtual Tariffa Tariffa { get; set; }
    }

    [Table("ComponenteInfo")]
    public class ComponenteInfo
    {
        [Key]
        public int Id { get; set; }
        public virtual InfoBox Categoria { get; set; }
        public int Quantita { get; set; }
    }

    [Table("ComuneDiNacitaInfoBox")]
    public class ComuneDiNascitaInfoBox
    {
        [Key]
        public string Id { get; set; }
        public string IdEsterno { get; set; }
        public string Descrizione { get; set; }
    }

    [Table("InfoBox")]
    public class InfoBox
    {
        [Key]
        public int Id { get; set; }
        public string IdInfoBox { get; set; }
        public string IdEsterno { get; set; }
        public string Descrizione { get; set; }
    }

    [Table("Iva")]
    public class Iva
    {
        public string Id { get; set; }
        public string IdEsterno { get; set; }
        public string Descrizione { get; set; }
        public decimal Aliquota { get; set; }
    }

    [Table("Tariffa")]
    public class Tariffa
    {
        [Key]
        public string Id { get; set; }
        public string IdEsterno { get; set; }
        public string Descrizione{ get; set; }
        public decimal Importo { get; set; }
        public bool? Rate { get; set; }
        public bool? ScontoAbilitato { get; set; }
    }

    [Table("Reservation")]
    public class Reservation
    {
        [Key]
        public string Id { get; set; }
        public string IdEsterno { get; set; }
        public int? ItemPrenotStatus { get; set; }
        public int? Posti { get; set; }
        public int? PostiOccupati { get; set; }
        public int? Tipo { get; set; }
        public DateTime? DataOraFine { get; set; }
        public DateTime? DataOraInizio { get; set; }
        public int? Fila { get; set; }
        public int? IngResiduiIscriz { get; set; }
        public bool? IsFruito { get; set; }
        public string Nota { get; set; }
        public string NotaPrescrizione { get; set; }
        public string NotaTrattamento { get; set; }
        public string NumPiaz { get; set; }
        public int? Riga { get; set; }
        public int? Status { get; set; }
        public string Telefono { get; set; }
        public int? TipoConferma { get; set; }
        public int IdOrario { get; set; }

        public virtual InfoBox Livello { get; set; }
        public virtual InfoBox Item { get; set; }
        public virtual InfoBox Spazio { get; set; }
        public virtual InfoBox Personale { get; set; }
        public virtual InfoBox Mappa { get; set; }
        public virtual HotelPrenotazione HotelPrenotazione { get; set; }
        public virtual Anagrafica Anagrafica { get; set; }
        // public virtual Iscrizione Iscrizione { get; set; }
        public string IdIscrizione { get; set; }
    }

    [Table("Iscrizione")]
    public class Iscrizione
    {
        [Key]
        public string Id { get; set; }
        public string IdEsterno { get; set; }
        public DateTime DataAl { get; set; }
        public DateTime DataDal { get; set; }
        public string Descrizione { get; set; }
        public int? IngressiAcquistati { get; set; }
        public int? IngressiFruiti { get; set; }
        public int? IngressiResidui { get; set; }
        public bool? IsRinnovabile { get; set; }
        public int? RecuperiDisponibili { get; set; }
        public DateTime? RecuperoDataFine { get; set; }
        public int? Status { get; set; }
        public int? TipoGestione { get; set; }
        public int TipoIscrizione { get; set; }
        public bool TutoreMancante { get; set; }
        public int IdServizio { get; set; }

        public virtual Iscrizione[] Componenti { get; set; }
        public virtual Listino Listino { get; set; }
    }

    [Table("HotelPrenotazione")]
    public class HotelPrenotazione
    {
        [Key]
        public string Id { get; set; }
        public string IdEsterno { get; set; }
        public DateTime DataFine { get; set; }
        public DateTime DataInizio { get; set; }
        public string Email { get; set; }
        public string Impianto { get; set; }
        public string Nominativo { get; set; }
        public int? NrPersone { get; set; }
        public string NumeroCamera { get; set; }
        public string Telefono { get; set; }
        public int? TipoPrenotazione { get; set; }
        public int IdHotel { get; set; }

        // public virtual Reservation Reservation { get; set; }
    }
}