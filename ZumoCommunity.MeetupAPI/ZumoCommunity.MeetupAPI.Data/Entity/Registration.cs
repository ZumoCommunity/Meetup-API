﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZumoCommunity.MeetupAPI.Data.Entity
{
	public class Registration : _Data
	{
		public string Email { get; set; }

		public string FullName { get; set; }

		public bool IsSubscribeForNews { get; set; }

		public Guid MeetupId { get; set; }

		#region Navigation

		[ForeignKey(nameof(MeetupId))]
		public virtual Meetup Meetup { get; set; }

		#endregion
	}
}
