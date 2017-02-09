namespace ZumoCommunity.MeetupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssetTypeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TopicAssets", "AssetType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TopicAssets", "AssetType");
        }
    }
}
