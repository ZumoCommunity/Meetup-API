using System;
using System.Collections.Generic;

namespace ZumoCommunity.MeetupAPI.Infrastructure.Data.Entity
{
	public interface ILocationData : IData
	{
		string Title { get; set; }
		string Address { get; set; }
		string AdditionalDirections { get; set; }
		double Latitude { get; set; }
		double Longitude { get; set; }

		IEnumerable<Guid> MeetupsIds { get; set; }
	}
}
