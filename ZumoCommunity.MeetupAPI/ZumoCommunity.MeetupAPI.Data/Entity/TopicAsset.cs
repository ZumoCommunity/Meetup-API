using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZumoCommunity.MeetupAPI.Data.Enum;

namespace ZumoCommunity.MeetupAPI.Data.Entity
{
	public class TopicAsset : _Data
	{
		[Required]
		public string Title { get; set; }

		[Required]
		public string AssetUrl { get; set; }

		[Required]
		public Guid TopicId { get; set; }

		[Required]
		public int AssetType { get; set; }

		[NotMapped]
		public AssetType AssetTypeCode
		{
			get { return (AssetType)AssetType; }
			set { AssetType = (int)value; }
		}

		#region Navigation

		[ForeignKey(nameof(TopicId))]
		public virtual Topic Topic { get; set; }

		#endregion
	}
}
