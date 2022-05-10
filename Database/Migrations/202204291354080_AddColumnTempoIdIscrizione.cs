namespace AquardensDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnTempoIdIscrizione : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservation", "Iscrizione_Id", "dbo.Iscrizione");
            DropIndex("dbo.Reservation", new[] { "Iscrizione_Id" });
            AddColumn("dbo.Reservation", "IdIscrizione", c => c.Int());
            DropColumn("dbo.Reservation", "Iscrizione_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservation", "Iscrizione_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Reservation", "IdIscrizione");
            CreateIndex("dbo.Reservation", "Iscrizione_Id");
            AddForeignKey("dbo.Reservation", "Iscrizione_Id", "dbo.Iscrizione", "Id");
        }
    }
}
