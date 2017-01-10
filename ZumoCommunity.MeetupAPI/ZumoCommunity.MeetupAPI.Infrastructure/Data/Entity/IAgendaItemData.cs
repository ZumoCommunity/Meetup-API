using System;
using System.Collections.Generic;

namespace ZumoCommunity.MeetupAPI.Infrastructure.Data.Entity
{
	public interface IAgendaItemData : IData
	{
		Guid MeetupId { get; set; }
		Guid TopicId { get; set; }

		IEnumerable<Guid> SpeakersIds { get; set; }
	}
}
