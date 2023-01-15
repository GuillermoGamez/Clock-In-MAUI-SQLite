using System;
using SQLite;

namespace Clock_In_System_with_MAUI_and_SQLite.Model
{
	[Table("ClockEntries")]
	public class ClockEntry
	{
		[PrimaryKey, AutoIncrement]
		public int ClockEntryId { get; set; }
		public DateTime DateTime { get; set; }
		public int ClockEntryType { get; set; }
		public int UserId { get; set; }
	}
}