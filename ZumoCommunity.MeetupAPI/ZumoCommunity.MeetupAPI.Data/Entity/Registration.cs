using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZumoCommunity.MeetupAPI.Data.Entity
{
	public class Registration : _Data
	{
		[Required]
		public string Email { get; set; }

		[Required]
		public string FullName { get; set; }

		[Required]
		public bool IsSubscribeForNews { get; set; }

		[Required]
		public Guid MeetupId { get; set; }

		#region Navigation

		[ForeignKey(nameof(MeetupId))]
		public virtual Meetup Meetup { get; set; }

		#endregion
	}
}
