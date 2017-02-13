namespace ZumoCommunity.MeetupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpeakerAgendaItemManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Speakers", "AgendaItem_Id", "dbo.AgendaItems");
            DropIndex("dbo.Speakers", new[] { "AgendaItem_Id" });
            CreateTable(
                "dbo.SpeakerAgendaItems",
                c => new
                    {
                        Speaker_Id = c.Guid(nullable: false),
                        AgendaItem_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Speaker_Id, t.AgendaItem_Id })
                .ForeignKey("dbo.Speakers", t => t.Speaker_Id, cascadeDelete: true)
                .ForeignKey("dbo.AgendaItems", t => t.AgendaItem_Id, cascadeDelete: true)
                .Index(t => t.Speaker_Id)
                .Index(t => t.AgendaItem_Id);
            
            DropColumn("dbo.Speakers", "AgendaItem_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Speakers", "AgendaItem_Id", c => c.Guid());
            DropForeignKey("dbo.SpeakerAgendaItems", "AgendaItem_Id", "dbo.AgendaItems");
            DropForeignKey("dbo.SpeakerAgendaItems", "Speaker_Id", "dbo.Speakers");
            DropIndex("dbo.SpeakerAgendaItems", new[] { "AgendaItem_Id" });
            DropIndex("dbo.SpeakerAgendaItems", new[] { "Speaker_Id" });
            DropTable("dbo.SpeakerAgendaItems");
            CreateIndex("dbo.Speakers", "AgendaItem_Id");
            AddForeignKey("dbo.Speakers", "AgendaItem_Id", "dbo.AgendaItems", "Id");
        }
    }
}
