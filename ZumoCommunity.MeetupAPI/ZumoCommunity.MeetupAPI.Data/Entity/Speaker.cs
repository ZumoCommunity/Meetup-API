using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZumoCommunity.MeetupAPI.Data.Entity
{
	public class Speaker : _Data
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string Bio { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string PhotoUrl { get; set; }

		public string FaceBookUrl { get; set; }

		public string GitHubUrl { get; set; }

		public string LinkedInUrl { get; set; }

		public string TwitterUrl { get; set; }

		public string YouTubeUrl { get; set; }

		public string MvpUrl { get; set; }

		public string WebSiteUrl { get; set; }

		#region Navigation

		public virtual ICollection<AgendaItem> AgendaItems { get; set; }

		#endregion

		[NotMapped]
		public IEnumerable<Guid> AgendaItemsIds { get; set; }
	}
}
