using System.Data.Entity;
using ZumoCommunity.MeetupAPI.Data.Entity;

namespace ZumoCommunity.MeetupAPI.Data.Context
{
	public class DataContext : DbContext
	{
		public DataContext(string connectionString)
			: base(connectionString)
		{
		}
		
		public DbSet<AgendaItem> AgendaItems { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<Meetup> Meetups { get; set; }
		public DbSet<Partner> Partners { get; set; }
		public DbSet<Registration> Registrations { get; set; }
		public DbSet<Speaker> Speakers { get; set; }
		public DbSet<Topic> Topics { get; set; }
		public DbSet<TopicAsset> TopicAssets { get; set; }
	}
}
