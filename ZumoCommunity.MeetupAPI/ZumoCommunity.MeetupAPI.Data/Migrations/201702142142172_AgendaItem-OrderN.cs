namespace ZumoCommunity.MeetupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgendaItemOrderN : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AgendaItems", "OrderN", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AgendaItems", "OrderN");
        }
    }
}
