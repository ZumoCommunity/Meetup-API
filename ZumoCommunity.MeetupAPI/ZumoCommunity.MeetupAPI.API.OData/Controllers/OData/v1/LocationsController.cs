using ZumoCommunity.MeetupAPI.API.OData.Authentication;
using ZumoCommunity.MeetupAPI.Data.Entity;

namespace ZumoCommunity.MeetupAPI.API.OData.Controllers.OData.v1
{
	[MasterApiKeyAuthentication(AccessLevel.Master)]
	public class LocationsController : _Controller<Location>
	{
	}
}
