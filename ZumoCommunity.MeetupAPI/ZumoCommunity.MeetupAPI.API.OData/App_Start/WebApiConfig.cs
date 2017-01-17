using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using ZumoCommunity.MeetupAPI.Data.Entity;

namespace ZumoCommunity.MeetupAPI.API.OData
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			var cors = new EnableCorsAttribute("*", "*", "*");
			config.EnableCors(cors);

			var builder = new ODataConventionModelBuilder();
			config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);

			builder.EntitySet<AgendaItem>("AgendaItems");
			builder.EntitySet<Location>("Locations");
			builder.EntitySet<Meetup>("Meetups");
			builder.EntitySet<Partner>("Partners");
			builder.EntitySet<Registration>("Registrations");
			builder.EntitySet<Speaker>("Speakers");
			builder.EntitySet<TopicAsset>("TopicAssets");
			builder.EntitySet<Topic>("Topics");

			config.MapODataServiceRoute("odata", "odata/v1", builder.GetEdmModel());
		}
	}
}