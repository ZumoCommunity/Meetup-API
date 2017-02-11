namespace ZumoCommunity.MeetupAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeetupAttendanceFeeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetups", "AttendanceFee", c => c.Int());
            AddColumn("dbo.Meetups", "AttendanceFeeCurency", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meetups", "AttendanceFeeCurency");
            DropColumn("dbo.Meetups", "AttendanceFee");
        }
    }
}
