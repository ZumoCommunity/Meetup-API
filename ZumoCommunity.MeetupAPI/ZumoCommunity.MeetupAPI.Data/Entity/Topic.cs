using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZumoCommunity.MeetupAPI.Data.Entity
{
	public class Topic : _Data
	{
		[Required]
		public string Title { get; set; }

		public string Description { get; set; }

		#region Navigation

		public virtual ICollection<TopicAsset> TopicAssets { get; set; }

		#endregion

		[NotMapped]
		public IEnumerable<Guid> TopicAssetsIds { get; set; }
	}
}
