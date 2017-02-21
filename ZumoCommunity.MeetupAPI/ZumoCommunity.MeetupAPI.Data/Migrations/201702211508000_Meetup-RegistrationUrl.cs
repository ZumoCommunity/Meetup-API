namespace ZumoCommunity.MeetupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeetupRegistrationUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetups", "RegistrationUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meetups", "RegistrationUrl");
        }
    }
}
