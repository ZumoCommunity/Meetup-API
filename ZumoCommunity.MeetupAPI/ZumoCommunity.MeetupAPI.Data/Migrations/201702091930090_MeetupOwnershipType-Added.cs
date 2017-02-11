namespace ZumoCommunity.MeetupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeetupOwnershipTypeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetups", "MeetupOwnershipType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meetups", "MeetupOwnershipType");
        }
    }
}
