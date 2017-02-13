using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using ZumoCommunity.ConfigurationAPI.Provider;
using ZumoCommunity.ConfigurationAPI.Readers.Common;
using ZumoCommunity.MeetupAPI.API.OData.Helpers;
using ZumoCommunity.MeetupAPI.Data.Context;

namespace ZumoCommunity.MeetupAPI.API.OData
{
	public class Global : HttpApplication
	{
		public static ConfigurationProvider ConfigurationProvider;

		protected void Application_Start(object sender, EventArgs e)
		{
			ConfigurationProvider = new ConfigurationProvider();

			var environmentReader = new EnvironmentVariablesReader();
			var appSettingsReader = new AppSettingsReader();
			var connectionStringsReader = new ConnectionStringsReader();

			Task.WaitAll(
				Task.Run(() => ConfigurationProvider.AddConfigurationReaderAsync(environmentReader)),
				Task.Run(() => ConfigurationProvider.AddConfigurationReaderAsync(appSettingsReader)),
				Task.Run(() => ConfigurationProvider.AddConfigurationReaderAsync(connectionStringsReader)));

			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			var dataContextTask = Task.Run(Factory.GetDataContextAsync);
			dataContextTask.Wait();

			var database = dataContextTask.Result.Database;
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Data.Migrations.Configuration>());
			database.Initialize(false);
		}

		protected void Session_Start(object sender, EventArgs e)
		{
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{
		}

		protected void Application_Error(object sender, EventArgs e)
		{
		}

		protected void Session_End(object sender, EventArgs e)
		{
		}

		protected void Application_End(object sender, EventArgs e)
		{
		}
	}
}