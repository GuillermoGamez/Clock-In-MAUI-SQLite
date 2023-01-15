using System;
using SQLite;
using Clock_In_System_with_MAUI_and_SQLite.Configuration;
using Clock_In_System_with_MAUI_and_SQLite.Model;
using Clock_In_System_with_MAUI_and_SQLite.Service;

namespace Clock_In_System_with_MAUI_and_SQLite.Service
{
	public class UserService
	{
        SQLiteAsyncConnection Db;

        public UserService()
		{
		}

        async Task Init()
        {
            if (Db != null)
                return;

            Db = new SQLiteAsyncConnection(DBConfig.DatabasePath, DBConfig.Flags);
            await Db.CreateTableAsync<User>();
        }

        public async Task<List<User>> GetAllUsers()
        {
            await Init();
            var clockEntry = await Db.Table<User>().ToListAsync();
            return clockEntry;
        }

        public async Task<int> AddUser(User user)
        {
            await Init();
            return await Db.InsertAsync(user);
        }

        public async Task<int> UpdateUser(User user)
        {
            await Init();
            return await Db.UpdateAsync(user);
        }

        public async Task<User> GetUser(string username)
        {
            await Init();
            var userList = await GetAllUsers();
            var currentUser = userList.Where(u => u.UserName == username);

            if (currentUser.Any())
                return currentUser.First();

            return null;
        }

        public async Task<bool> DoesUserExist(string username)
        {
            await Init();
            List<User> users;
            users = await Db.Table<User>()
                .Where(u => u.UserName == username)
                .ToListAsync();

            if (users.Count != 0)
                return true;

            return false;
        }
    }
}