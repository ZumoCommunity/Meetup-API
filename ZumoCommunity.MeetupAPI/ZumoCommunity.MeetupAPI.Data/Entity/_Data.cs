using System;
using System.ComponentModel.DataAnnotations;
using ZumoCommunity.MeetupAPI.Infrastructure.Data.Entity;

namespace ZumoCommunity.MeetupAPI.Data.Entity
{
	public abstract class _Data : IData
	{
		[Key]
		[Required]
		public Guid Id { get; set; }

		public virtual bool IsDataValid()
		{
			if (Id == Guid.Empty)
			{
				return false;
			}

			return true;
		}
	}
}
