using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZumoCommunity.MeetupAPI.Infrastructure.Data.Entity;

namespace ZumoCommunity.MeetupAPI.Data.Entity
{
	public class Location : _Data, ILocationData
	{
		[Required]
		public string Title { get; set; }

		[Required]
		public string Address { get; set; }

		public string AdditionalDirections { get; set; }

		[Required]
		public double Latitude { get; set; }

		[Required]
		public double Longitude { get; set; }

		#region Navigation

		public virtual ICollection<IMeetupData> Meetups { get; set; }

		#endregion

		[NotMapped]
		public IEnumerable<Guid> MeetupsIds { get; set; }
	}
}
