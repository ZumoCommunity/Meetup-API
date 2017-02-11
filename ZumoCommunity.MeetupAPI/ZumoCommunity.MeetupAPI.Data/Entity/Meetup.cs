using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZumoCommunity.MeetupAPI.Data.Enum;

namespace ZumoCommunity.MeetupAPI.Data.Entity
{
	public class Meetup : _Data
	{
		[Required]
		public string Title { get; set; }

		[Required]
		public DateTime DateTimeBegin { get; set; }

		[Required]
		public DateTime DateTimeEnd { get; set; }

		[Required]
		[Index(IsUnique = true)]
		[MaxLength(300)]
		public string Uri { get; set; }

		[Required]
		public Guid LocationId { get; set; }

		[Required]
		public MeetupOwnershipType MeetupOwnershipType { get; set; }

		public int? AttendanceFee { get; set; }

		[MaxLength(10)]
		public string AttendanceFeeCurency { get; set; }

		#region Navigation

		[ForeignKey(nameof(LocationId))]
		public virtual Location Location { get; set; }

		public virtual ICollection<Partner> Partners { get; set; }

		public virtual ICollection<AgendaItem> AgendaItems { get; set; }

		public virtual ICollection<Registration> Registrations { get; set; }

		#endregion

		#region Validation

		public override bool IsDataValid()
		{
			if (DateTimeEnd < DateTimeBegin)
			{
				return false;
			}

			if (Location == null || LocationId == Guid.Empty)
			{
				return false;
			}

			return base.IsDataValid();
		}

		#endregion

		[NotMapped]
		public IEnumerable<Guid> PartnersIds { get; set; }

		[NotMapped]
		public IEnumerable<Guid> AgendaItemsIds { get; set; }

		[NotMapped]
		public IEnumerable<Guid> RegistrationsIds { get; set; }
	}
}
