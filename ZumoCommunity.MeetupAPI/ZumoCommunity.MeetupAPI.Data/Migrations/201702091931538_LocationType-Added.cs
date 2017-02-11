namespace ZumoCommunity.MeetupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationTypeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "LocationType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "LocationType");
        }
    }
}
