using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZumoCommunity.MeetupAPI.Infrastructure.Data.Entity;

namespace ZumoCommunity.MeetupAPI.Data.Entity
{
	public class Topic : _Data, ITopicData
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
