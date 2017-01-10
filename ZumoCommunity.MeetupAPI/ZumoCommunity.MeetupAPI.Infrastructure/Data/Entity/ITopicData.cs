using System;
using System.Collections.Generic;

namespace ZumoCommunity.MeetupAPI.Infrastructure.Data.Entity
{
	public interface ITopicData : IData
	{
		string Title { get; set; }
		string Description { get; set; }

		IEnumerable<Guid> TopicAssetsIds { get; set; }
	}
}
