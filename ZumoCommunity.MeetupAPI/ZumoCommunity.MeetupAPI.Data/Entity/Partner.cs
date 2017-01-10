﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZumoCommunity.MeetupAPI.Infrastructure.Data.Entity;

namespace ZumoCommunity.MeetupAPI.Data.Entity
{
	public class Partner : _Data, IPartnerData
	{
		[Required]
		public string Title { get; set; }

		public string Description { get; set; }

		public string LogoUrl { get; set; }

		public string WebSiteUrl { get; set; }

		#region Navigation

		public virtual ICollection<Meetup> Meetups { get; set; }

		#endregion

		[NotMapped]
		public IEnumerable<Guid> MeetupsIds { get; set; }
	}
}
