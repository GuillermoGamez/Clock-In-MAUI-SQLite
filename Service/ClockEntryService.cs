using System;
using SQLite;
using Clock_In_System_with_MAUI_and_SQLite.Configuration;
using Clock_In_System_with_MAUI_and_SQLite.Model;
using Clock_In_System_with_MAUI_and_SQLite.Service;

namespace Clock_In_System_with_MAUI_and_SQLite.Service
{
	public class ClockEntryService
	{
		SQLiteAsyncConnection Db;

		public ClockEntryService()
		{
		}

		async Task Init()
		{
			if (Db != null)
				return;

			Db = new SQLiteAsyncConnection(DBConfig.DatabasePath, DBConfig.Flags);
			await Db.CreateTableAsync<ClockEntry>();
		}

		public async Task<List<ClockEntry>> GetAllClockEntries()
		{
			await Init();
			var clockEntry = await Db.Table<ClockEntry>().ToListAsync();
			return clockEntry;
		}

		public async Task<ClockEntry> GetLastEntry(User user)
		{
			await Init();
			var clockEntry = await Db.Table<ClockEntry>().ToListAsync();
			return clockEntry.OrderByDescending(c => c.DateTime).FirstOrDefault();
		}

		public async Task<int> AddClockEntry(ClockEntry entry)
		{
			await Init();
			return await Db.InsertAsync(entry);
		}

		public async Task<int> UpdateClockEntry(ClockEntry entry)
		{
			await Init();
			return await Db.UpdateAsync(entry);
		}
    }
}