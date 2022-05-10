using System.Data.Entity;

namespace AquardensDatabase.Entity
{
    public class EFContext : DbContext
    {
        public DbSet<Anagrafica> Anagrafica { get; set; }
        public DbSet<AnagraficaIndirizzo> AnagraficaIndirizzo { get; set; }
        public DbSet<DatiStatistici> DatiStatistici { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Listino> Listino { get; set; }
        public DbSet<ComponenteInfo> ComponenteInfo { get; set; }
        public DbSet<ComuneDiNascitaInfoBox> ComuneDiNascitaInfoBox { get; set; }
        public DbSet<InfoBox> InfoBox { get; set; }
        public DbSet<Iva> Iva { get; set; }
        public DbSet<Tariffa> Tariffa { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Iscrizione> Iscrizione { get; set; }
        public DbSet<HotelPrenotazione> HotelPrenotazione { get; set; }

        public EFContext() : base("Server=.\\SQLExpress;Database=AquardensDB;Trusted_Connection=True;MultipleActiveResultSets=true")
        {

        }

        public EFContext(string ConnectionString) : base("Server=.\\SQLExpress;Database=AquardensDB;Trusted_Connection=True;MultipleActiveResultSets=true")
        {
            System.Data.Entity.Database.SetInitializer<EFContext>(new CreateDatabaseIfNotExists<EFContext>());
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Anagrafica>().HasOptional(x => x.IndirizzoPredefinito);
        }
    }
}