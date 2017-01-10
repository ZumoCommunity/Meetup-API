using System;
using System.Collections.Generic;

namespace ZumoCommunity.MeetupAPI.Infrastructure.Data.Entity
{
	public interface IPartnerData : IData
	{
		string Title { get; set; }
		string WebSiteUrl { get; set; }
		string LogoUrl { get; set; }
		string Description { get; set; }

		IEnumerable<Guid> MeetupsIds { get; set; }
	}
}
