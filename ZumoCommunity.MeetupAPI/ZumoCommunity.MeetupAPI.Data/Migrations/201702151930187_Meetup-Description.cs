namespace ZumoCommunity.MeetupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeetupDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetups", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meetups", "Description");
        }
    }
}
