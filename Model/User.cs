using System;
using SQLite;

namespace Clock_In_System_with_MAUI_and_SQLite.Model
{
	[Table("Users")]
	public class User
	{
		[PrimaryKey, AutoIncrement]
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}