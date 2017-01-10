using System;

namespace ZumoCommunity.MeetupAPI.Infrastructure.Data.Entity
{
	public interface ITopicAssetData : IData
	{
		Guid TopicId { get; set; }
		string Title { get; set; }
		string AssetUrl { get; set; }
	}
}
