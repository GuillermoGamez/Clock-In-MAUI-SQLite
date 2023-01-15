using System;
using SQLite;

namespace Clock_In_System_with_MAUI_and_SQLite.Configuration
{
	public static class DBConfig
	{
		public const string DatabaseFileName = "db.db3";

		public const SQLiteOpenFlags Flags =
			SQLiteOpenFlags.ReadWrite |
			SQLiteOpenFlags.Create |
			SQLiteOpenFlags.SharedCache;

		public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
	}
}