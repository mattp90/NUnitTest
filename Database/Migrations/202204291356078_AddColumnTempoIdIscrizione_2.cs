namespace AquardensDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnTempoIdIscrizione_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservation", "IdIscrizione", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservation", "IdIscrizione", c => c.Int());
        }
    }
}
