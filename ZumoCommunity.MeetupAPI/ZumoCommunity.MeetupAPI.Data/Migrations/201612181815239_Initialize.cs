namespace ZumoCommunity.MeetupAPI.Data.Migrations
{
	using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgendaItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MeetupId = c.Guid(nullable: false),
                        TopicId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meetups", t => t.MeetupId, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.MeetupId)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Meetups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        DateTimeBegin = c.DateTime(nullable: false),
                        DateTimeEnd = c.DateTime(nullable: false),
                        Uri = c.String(nullable: false, maxLength: 300),
                        LocationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.Uri, unique: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        AdditionalDirections = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        LogoUrl = c.String(),
                        WebSiteUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(),
                        FullName = c.String(),
                        IsSubscribeForNews = c.Boolean(nullable: false),
                        MeetupId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meetups", t => t.MeetupId, cascadeDelete: true)
                .Index(t => t.MeetupId);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(nullable: false),
                        Bio = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhotoUrl = c.String(nullable: false),
                        FaceBookUrl = c.String(),
                        GitHubUrl = c.String(),
                        LinkedInUrl = c.String(),
                        TwitterUrl = c.String(),
                        YouTubeUrl = c.String(),
                        AgendaItem_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgendaItems", t => t.AgendaItem_Id)
                .Index(t => t.AgendaItem_Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TopicAssets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        AssetUrl = c.String(),
                        TopicId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.PartnerMeetups",
                c => new
                    {
                        Partner_Id = c.Guid(nullable: false),
                        Meetup_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Partner_Id, t.Meetup_Id })
                .ForeignKey("dbo.Partners", t => t.Partner_Id, cascadeDelete: true)
                .ForeignKey("dbo.Meetups", t => t.Meetup_Id, cascadeDelete: true)
                .Index(t => t.Partner_Id)
                .Index(t => t.Meetup_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AgendaItems", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.TopicAssets", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Speakers", "AgendaItem_Id", "dbo.AgendaItems");
            DropForeignKey("dbo.Registrations", "MeetupId", "dbo.Meetups");
            DropForeignKey("dbo.PartnerMeetups", "Meetup_Id", "dbo.Meetups");
            DropForeignKey("dbo.PartnerMeetups", "Partner_Id", "dbo.Partners");
            DropForeignKey("dbo.Meetups", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.AgendaItems", "MeetupId", "dbo.Meetups");
            DropIndex("dbo.PartnerMeetups", new[] { "Meetup_Id" });
            DropIndex("dbo.PartnerMeetups", new[] { "Partner_Id" });
            DropIndex("dbo.TopicAssets", new[] { "TopicId" });
            DropIndex("dbo.Speakers", new[] { "AgendaItem_Id" });
            DropIndex("dbo.Registrations", new[] { "MeetupId" });
            DropIndex("dbo.Meetups", new[] { "LocationId" });
            DropIndex("dbo.Meetups", new[] { "Uri" });
            DropIndex("dbo.AgendaItems", new[] { "TopicId" });
            DropIndex("dbo.AgendaItems", new[] { "MeetupId" });
            DropTable("dbo.PartnerMeetups");
            DropTable("dbo.TopicAssets");
            DropTable("dbo.Topics");
            DropTable("dbo.Speakers");
            DropTable("dbo.Registrations");
            DropTable("dbo.Partners");
            DropTable("dbo.Locations");
            DropTable("dbo.Meetups");
            DropTable("dbo.AgendaItems");
        }
    }
}
