using ZumoCommunity.MeetupAPI.API.OData.Authentication;
using ZumoCommunity.MeetupAPI.Data.Entity;

namespace ZumoCommunity.MeetupAPI.API.OData.Controllers.OData.v1
{
	[HardcodedAuthentication(AccessLevel.Master)]
	public class MeetupsController : _Controller<Meetup>
	{
	}
}
