using System;

namespace ZumoCommunity.MeetupAPI.Infrastructure.Data.Entity
{
	public interface IData
	{
		Guid Id { get; set; }

		bool IsDataValid();
	}
}
