using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZumoCommunity.MeetupAPI.Data.Entity
{
	public class AgendaItem : _Data
	{
		[Required]
		public Guid MeetupId { get; set; }

		[Required]
		public Guid TopicId { get; set; }

		#region Navigation

		public virtual Meetup Meetup { get; set; }

		public virtual Topic Topic { get; set; }

		public virtual ICollection<Speaker> Speakers { get; set; }

		#endregion

		[NotMapped]
		public IEnumerable<Guid> SpeakersIds { get; set; }
	}
}
