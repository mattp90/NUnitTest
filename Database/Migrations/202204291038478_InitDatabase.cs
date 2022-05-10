namespace AquardensDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anagrafica",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdEsterno = c.String(),
                        CodiceDestinatario = c.String(),
                        CodiceFiscale = c.String(),
                        Cognome = c.String(),
                        DataNascita = c.DateTime(),
                        Impianto = c.String(),
                        IsAzienda = c.Boolean(),
                        Nome = c.String(),
                        PartitaIva = c.String(),
                        RagioneSociale = c.String(),
                        Sesso = c.String(),
                        Cellulare = c.String(),
                        CellularePrefissoInt = c.String(),
                        CodiceLotteria = c.String(),
                        Email = c.String(),
                        IdUtenza = c.String(),
                        IdUtenzaEsterno = c.String(),
                        Immagine = c.Binary(),
                        IsPersonaFisica = c.Boolean(nullable: false),
                        Nota = c.String(),
                        NotaBreve = c.String(),
                        Password = c.String(),
                        Privacy = c.Boolean(),
                        Telefono = c.String(),
                        Username = c.String(),
                        ComuneNascita_Id = c.String(maxLength: 128),
                        Convenzione_Id = c.Int(),
                        DatiStatistici_Id = c.String(maxLength: 128),
                        IndirizzoPredefinito_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComuneDiNacitaInfoBox", t => t.ComuneNascita_Id)
                .ForeignKey("dbo.InfoBox", t => t.Convenzione_Id)
                .ForeignKey("dbo.DatiStatistici", t => t.DatiStatistici_Id)
                .ForeignKey("dbo.AnagraficaIndirizzo", t => t.IndirizzoPredefinito_Id)
                .Index(t => t.ComuneNascita_Id)
                .Index(t => t.Convenzione_Id)
                .Index(t => t.DatiStatistici_Id)
                .Index(t => t.IndirizzoPredefinito_Id);
            
            CreateTable(
                "dbo.ComuneDiNacitaInfoBox",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdEsterno = c.String(),
                        Descrizione = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InfoBox",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdInfoBox = c.String(),
                        IdEsterno = c.String(),
                        Descrizione = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DatiStatistici",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DataInserimento = c.DateTime(),
                        Convenzione_Id = c.Int(),
                        Fonte_Id = c.Int(),
                        GruppoAnagrafica_Id = c.Int(),
                        Professione_Id = c.Int(),
                        StatoCivile_Id = c.Int(),
                        TariffaPredefinita_Id = c.Int(),
                        TipoIscritto_Id = c.Int(),
                        TitoloStudio_Id = c.Int(),
                        ZonaResidenza_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InfoBox", t => t.Convenzione_Id)
                .ForeignKey("dbo.InfoBox", t => t.Fonte_Id)
                .ForeignKey("dbo.InfoBox", t => t.GruppoAnagrafica_Id)
                .ForeignKey("dbo.InfoBox", t => t.Professione_Id)
                .ForeignKey("dbo.InfoBox", t => t.StatoCivile_Id)
                .ForeignKey("dbo.InfoBox", t => t.TariffaPredefinita_Id)
                .ForeignKey("dbo.InfoBox", t => t.TipoIscritto_Id)
                .ForeignKey("dbo.InfoBox", t => t.TitoloStudio_Id)
                .ForeignKey("dbo.InfoBox", t => t.ZonaResidenza_Id)
                .Index(t => t.Convenzione_Id)
                .Index(t => t.Fonte_Id)
                .Index(t => t.GruppoAnagrafica_Id)
                .Index(t => t.Professione_Id)
                .Index(t => t.StatoCivile_Id)
                .Index(t => t.TariffaPredefinita_Id)
                .Index(t => t.TipoIscritto_Id)
                .Index(t => t.TitoloStudio_Id)
                .Index(t => t.ZonaResidenza_Id);
            
            CreateTable(
                "dbo.AnagraficaIndirizzo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cap = c.String(),
                        Frazione = c.String(),
                        Indirizzo = c.String(),
                        IsPredefinito = c.Boolean(),
                        Localita = c.String(),
                        Provincia = c.String(),
                        Tipo = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdEsterno = c.String(),
                        Descrizione = c.String(),
                        Immagine = c.Binary(),
                        Impianto = c.String(),
                        TestoAggiuntivo = c.String(),
                        Tipo = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComponenteInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantita = c.Int(nullable: false),
                        Categoria_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InfoBox", t => t.Categoria_Id)
                .Index(t => t.Categoria_Id);
            
            CreateTable(
                "dbo.HotelPrenotazione",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdEsterno = c.String(),
                        DataFine = c.DateTime(nullable: false),
                        DataInizio = c.DateTime(nullable: false),
                        Email = c.String(),
                        Impianto = c.String(),
                        Nominativo = c.String(),
                        NrPersone = c.Int(),
                        NumeroCamera = c.String(),
                        Telefono = c.String(),
                        TipoPrenotazione = c.Int(),
                        IdHotel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Iscrizione",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdEsterno = c.String(),
                        DataAl = c.DateTime(nullable: false),
                        DataDal = c.DateTime(nullable: false),
                        Descrizione = c.String(),
                        IngressiAcquistati = c.Int(),
                        IngressiFruiti = c.Int(),
                        IngressiResidui = c.Int(),
                        IsRinnovabile = c.Boolean(),
                        RecuperiDisponibili = c.Int(),
                        RecuperoDataFine = c.DateTime(),
                        Status = c.Int(),
                        TipoGestione = c.Int(),
                        TipoIscrizione = c.Int(nullable: false),
                        TutoreMancante = c.Boolean(nullable: false),
                        IdServizio = c.Int(nullable: false),
                        Listino_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listino", t => t.Listino_Id)
                .Index(t => t.Listino_Id);
            
            CreateTable(
                "dbo.Listino",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdEsterno = c.String(),
                        Acconto = c.Decimal(precision: 18, scale: 2),
                        Costo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descrizione = c.String(),
                        Disponibilita = c.Int(),
                        IdVoucherScadenza = c.String(),
                        Immagine = c.Binary(),
                        Impianto = c.String(),
                        IsPrenotabile = c.Boolean(),
                        IsSingleSale = c.Boolean(),
                        TestoAggiuntivo = c.String(),
                        Tipo = c.Int(nullable: false),
                        ComponenteInfo_Id = c.Int(),
                        Iva_Id = c.String(maxLength: 128),
                        Tariffa_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComponenteInfo", t => t.ComponenteInfo_Id)
                .ForeignKey("dbo.Iva", t => t.Iva_Id)
                .ForeignKey("dbo.Tariffa", t => t.Tariffa_Id)
                .Index(t => t.ComponenteInfo_Id)
                .Index(t => t.Iva_Id)
                .Index(t => t.Tariffa_Id);
            
            CreateTable(
                "dbo.Iva",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdEsterno = c.String(),
                        Descrizione = c.String(),
                        Aliquota = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tariffa",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdEsterno = c.String(),
                        Descrizione = c.String(),
                        Importo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate = c.Boolean(),
                        ScontoAbilitato = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdEsterno = c.String(),
                        ItemPrenotStatus = c.Int(),
                        Posti = c.Int(),
                        PostiOccupati = c.Int(),
                        Tipo = c.Int(),
                        DataOraFine = c.DateTime(),
                        DataOraInizio = c.DateTime(),
                        Fila = c.Int(),
                        IngResiduiIscriz = c.Int(),
                        IsFruito = c.Boolean(),
                        Nota = c.String(),
                        NotaPrescrizione = c.String(),
                        NotaTrattamento = c.String(),
                        NumPiaz = c.String(),
                        Riga = c.Int(),
                        Status = c.Int(),
                        Telefono = c.String(),
                        TipoConferma = c.Int(),
                        IdOrario = c.Int(nullable: false),
                        Anagrafica_Id = c.String(maxLength: 128),
                        HotelPrenotazione_Id = c.String(maxLength: 128),
                        Iscrizione_Id = c.String(maxLength: 128),
                        Item_Id = c.Int(),
                        Livello_Id = c.Int(),
                        Mappa_Id = c.Int(),
                        Personale_Id = c.Int(),
                        Spazio_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Anagrafica", t => t.Anagrafica_Id)
                .ForeignKey("dbo.HotelPrenotazione", t => t.HotelPrenotazione_Id)
                .ForeignKey("dbo.Iscrizione", t => t.Iscrizione_Id)
                .ForeignKey("dbo.InfoBox", t => t.Item_Id)
                .ForeignKey("dbo.InfoBox", t => t.Livello_Id)
                .ForeignKey("dbo.InfoBox", t => t.Mappa_Id)
                .ForeignKey("dbo.InfoBox", t => t.Personale_Id)
                .ForeignKey("dbo.InfoBox", t => t.Spazio_Id)
                .Index(t => t.Anagrafica_Id)
                .Index(t => t.HotelPrenotazione_Id)
                .Index(t => t.Iscrizione_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.Livello_Id)
                .Index(t => t.Mappa_Id)
                .Index(t => t.Personale_Id)
                .Index(t => t.Spazio_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservation", "Spazio_Id", "dbo.InfoBox");
            DropForeignKey("dbo.Reservation", "Personale_Id", "dbo.InfoBox");
            DropForeignKey("dbo.Reservation", "Mappa_Id", "dbo.InfoBox");
            DropForeignKey("dbo.Reservation", "Livello_Id", "dbo.InfoBox");
            DropForeignKey("dbo.Reservation", "Item_Id", "dbo.InfoBox");
            DropForeignKey("dbo.Reservation", "Iscrizione_Id", "dbo.Iscrizione");
            DropForeignKey("dbo.Reservation", "HotelPrenotazione_Id", "dbo.HotelPrenotazione");
            DropForeignKey("dbo.Reservation", "Anagrafica_Id", "dbo.Anagrafica");
            DropForeignKey("dbo.Iscrizione", "Listino_Id", "dbo.Listino");
            DropForeignKey("dbo.Listino", "Tariffa_Id", "dbo.Tariffa");
            DropForeignKey("dbo.Listino", "Iva_Id", "dbo.Iva");
            DropForeignKey("dbo.Listino", "ComponenteInfo_Id", "dbo.ComponenteInfo");
            DropForeignKey("dbo.ComponenteInfo", "Categoria_Id", "dbo.InfoBox");
            DropForeignKey("dbo.Anagrafica", "IndirizzoPredefinito_Id", "dbo.AnagraficaIndirizzo");
            DropForeignKey("dbo.Anagrafica", "DatiStatistici_Id", "dbo.DatiStatistici");
            DropForeignKey("dbo.DatiStatistici", "ZonaResidenza_Id", "dbo.InfoBox");
            DropForeignKey("dbo.DatiStatistici", "TitoloStudio_Id", "dbo.InfoBox");
            DropForeignKey("dbo.DatiStatistici", "TipoIscritto_Id", "dbo.InfoBox");
            DropForeignKey("dbo.DatiStatistici", "TariffaPredefinita_Id", "dbo.InfoBox");
            DropForeignKey("dbo.DatiStatistici", "StatoCivile_Id", "dbo.InfoBox");
            DropForeignKey("dbo.DatiStatistici", "Professione_Id", "dbo.InfoBox");
            DropForeignKey("dbo.DatiStatistici", "GruppoAnagrafica_Id", "dbo.InfoBox");
            DropForeignKey("dbo.DatiStatistici", "Fonte_Id", "dbo.InfoBox");
            DropForeignKey("dbo.DatiStatistici", "Convenzione_Id", "dbo.InfoBox");
            DropForeignKey("dbo.Anagrafica", "Convenzione_Id", "dbo.InfoBox");
            DropForeignKey("dbo.Anagrafica", "ComuneNascita_Id", "dbo.ComuneDiNacitaInfoBox");
            DropIndex("dbo.Reservation", new[] { "Spazio_Id" });
            DropIndex("dbo.Reservation", new[] { "Personale_Id" });
            DropIndex("dbo.Reservation", new[] { "Mappa_Id" });
            DropIndex("dbo.Reservation", new[] { "Livello_Id" });
            DropIndex("dbo.Reservation", new[] { "Item_Id" });
            DropIndex("dbo.Reservation", new[] { "Iscrizione_Id" });
            DropIndex("dbo.Reservation", new[] { "HotelPrenotazione_Id" });
            DropIndex("dbo.Reservation", new[] { "Anagrafica_Id" });
            DropIndex("dbo.Listino", new[] { "Tariffa_Id" });
            DropIndex("dbo.Listino", new[] { "Iva_Id" });
            DropIndex("dbo.Listino", new[] { "ComponenteInfo_Id" });
            DropIndex("dbo.Iscrizione", new[] { "Listino_Id" });
            DropIndex("dbo.ComponenteInfo", new[] { "Categoria_Id" });
            DropIndex("dbo.DatiStatistici", new[] { "ZonaResidenza_Id" });
            DropIndex("dbo.DatiStatistici", new[] { "TitoloStudio_Id" });
            DropIndex("dbo.DatiStatistici", new[] { "TipoIscritto_Id" });
            DropIndex("dbo.DatiStatistici", new[] { "TariffaPredefinita_Id" });
            DropIndex("dbo.DatiStatistici", new[] { "StatoCivile_Id" });
            DropIndex("dbo.DatiStatistici", new[] { "Professione_Id" });
            DropIndex("dbo.DatiStatistici", new[] { "GruppoAnagrafica_Id" });
            DropIndex("dbo.DatiStatistici", new[] { "Fonte_Id" });
            DropIndex("dbo.DatiStatistici", new[] { "Convenzione_Id" });
            DropIndex("dbo.Anagrafica", new[] { "IndirizzoPredefinito_Id" });
            DropIndex("dbo.Anagrafica", new[] { "DatiStatistici_Id" });
            DropIndex("dbo.Anagrafica", new[] { "Convenzione_Id" });
            DropIndex("dbo.Anagrafica", new[] { "ComuneNascita_Id" });
            DropTable("dbo.Reservation");
            DropTable("dbo.Tariffa");
            DropTable("dbo.Iva");
            DropTable("dbo.Listino");
            DropTable("dbo.Iscrizione");
            DropTable("dbo.HotelPrenotazione");
            DropTable("dbo.ComponenteInfo");
            DropTable("dbo.Categoria");
            DropTable("dbo.AnagraficaIndirizzo");
            DropTable("dbo.DatiStatistici");
            DropTable("dbo.InfoBox");
            DropTable("dbo.ComuneDiNacitaInfoBox");
            DropTable("dbo.Anagrafica");
        }
    }
}
