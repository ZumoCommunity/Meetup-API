namespace ZumoCommunity.MeetupAPI.Infrastructure.Data.Entity
{
	public interface ISpeakerData : IData
	{
		string FullName { get; set; }
		string Email { get; set; }
		string Bio { get; set; }
		string PhotoUrl { get; set; }
		string FaceBookUrl { get; set; }
		string TwitterUrl { get; set; }
		string LinkedInUrl { get; set; }
		string GitHubUrl { get; set; }
		string YouTubeUrl { get; set; }
	}
}
