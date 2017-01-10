using System.Threading.Tasks;
using ZumoCommunity.MeetupAPI.Data.Context;
using ZumoCommunity.MeetupAPI.Infrastructure.Configuration;

namespace ZumoCommunity.MeetupAPI.API.OData.Helpers
{
	public static class Factory
	{
		public static async Task<DataContext> GetDataContextAsync()
		{
			var connectionString = await Global.ConfigurationProvider.GetConfigValueAsync(ConfigurationKeys.Database.ToKeyString());
			return new DataContext(connectionString);
		}
	}
}