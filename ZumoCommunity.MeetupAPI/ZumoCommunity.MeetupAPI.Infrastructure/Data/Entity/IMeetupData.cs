using System;
using System.Collections.Generic;

namespace ZumoCommunity.MeetupAPI.Infrastructure.Data.Entity
{
	public interface IMeetupData : IData
	{
		string Title { get; set; }
		DateTime DateTimeBegin { get; set; }
		DateTime DateTimeEnd { get; set; }
		string Uri { get; set; }
		Guid LocationId { get; set; }

		IEnumerable<Guid> PartnersIds { get; set; }
		IEnumerable<Guid> AgendaItemsIds { get; set; }
		IEnumerable<Guid> RegistrationsIds { get; set; }
	}
}
