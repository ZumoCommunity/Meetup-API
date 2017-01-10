using System;

namespace ZumoCommunity.MeetupAPI.Infrastructure.Data.Entity
{
	public interface IRegistrationData : IData
	{
		string FullName { get; set; }
		string Email { get; set; }
		bool IsSubscribeForNews { get; set; }
		Guid MeetupId { get; set; }
	}
}
