namespace ZumoCommunity.MeetupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TopicAssetAdjusted : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TopicAssets", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.TopicAssets", "AssetUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TopicAssets", "AssetUrl", c => c.String());
            AlterColumn("dbo.TopicAssets", "Title", c => c.String());
        }
    }
}
