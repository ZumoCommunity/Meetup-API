using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using ZumoCommunity.ConfigurationAPI.Provider;
using ZumoCommunity.ConfigurationAPI.Readers.Common;
using ZumoCommunity.MeetupAPI.API.OData.Helpers;

namespace ZumoCommunity.MeetupAPI.API.OData
{
	public class Global : HttpApplication
	{
		public static ConfigurationProvider ConfigurationProvider;

		protected void Application_Start(object sender, EventArgs e)
		{
			ConfigurationProvider = new ConfigurationProvider();

			var appSettingsReader = new AppSettingsReader();
			var connectionStringsReader = new ConnectionStringsReader();

			Task.WaitAll(
				Task.Run(() => ConfigurationProvider.AddConfigurationReaderAsync(appSettingsReader)),
				Task.Run(() => ConfigurationProvider.AddConfigurationReaderAsync(connectionStringsReader)));

			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			var dataContextTask = Factory.GetDataContextAsync();
			Task.Run(() => dataContextTask);
			dataContextTask.Result.Database.Initialize(false);
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