namespace ZumoCommunity.MeetupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PartnerIsFeatured : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Partners", "IsFeatured", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Partners", "IsFeatured");
        }
    }
}
