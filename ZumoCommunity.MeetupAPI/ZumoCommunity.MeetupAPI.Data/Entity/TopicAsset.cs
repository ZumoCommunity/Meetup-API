using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZumoCommunity.MeetupAPI.Data.Entity
{
	public class TopicAsset : _Data
	{
		public string Title { get; set; }

		public string AssetUrl { get; set; }

		public Guid TopicId { get; set; }

		#region Navigation

		[ForeignKey(nameof(TopicId))]
		public virtual Topic Topic { get; set; }

		#endregion
	}
}
