namespace ZumoCommunity.MeetupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpeakerMoreInfoAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Speakers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Speakers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Speakers", "MvpUrl", c => c.String());
            AddColumn("dbo.Speakers", "WebSiteUrl", c => c.String());
            DropColumn("dbo.Speakers", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Speakers", "FullName", c => c.String(nullable: false));
            DropColumn("dbo.Speakers", "WebSiteUrl");
            DropColumn("dbo.Speakers", "MvpUrl");
            DropColumn("dbo.Speakers", "LastName");
            DropColumn("dbo.Speakers", "FirstName");
        }
    }
}
