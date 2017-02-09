namespace ZumoCommunity.MeetupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistrationRequiredAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registrations", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Registrations", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registrations", "FullName", c => c.String());
            AlterColumn("dbo.Registrations", "Email", c => c.String());
        }
    }
}
