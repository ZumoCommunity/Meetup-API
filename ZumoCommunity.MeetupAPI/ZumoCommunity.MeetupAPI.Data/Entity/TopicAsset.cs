using System;
using System.ComponentModel.DataAnnotations.Schema;
using ZumoCommunity.MeetupAPI.Data.Enum;

namespace ZumoCommunity.MeetupAPI.Data.Entity
{
	public class TopicAsset : _Data
	{
		public string Title { get; set; }

		public string AssetUrl { get; set; }

		public Guid TopicId { get; set; }

		public AssetType AssetType { get; set; }

		#region Navigation

		[ForeignKey(nameof(TopicId))]
		public virtual Topic Topic { get; set; }

		#endregion
	}
}
