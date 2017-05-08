using RFID.Core.Models;
using SQLite.Net;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFID.Core.Interfaces;

namespace RFID.Core.Services
{
    public class SqliteDatabase : SQLiteAsyncConnection
    {
        public SqliteDatabase(Func<SQLiteConnectionWithLock> sqliteConnectionFunc, TaskScheduler taskScheduler = null,
            TaskCreationOptions taskCreationOptions = TaskCreationOptions.None)
            : base(sqliteConnectionFunc, taskScheduler, taskCreationOptions)
        {
        }

        public async Task InitializeAsync()
        {
            await CreateTableAsync<UserModel>();
            await SeedAsync();
        }

        private async Task SeedAsync()
        {
            await InsertAsync(new UserModel { Username = "user", IsLoggedIn = false });
        }

        public async Task<UserModel> LoadItem()
        {
            return await Table<UserModel>().FirstOrDefaultAsync();
        }

        public async Task<List<UserModel>> GetAll()
        {
            return await Table<UserModel>().ToListAsync();
        }

        public async Task InsertOrUpdateAsync(UserModel i)
        {
            await this.InsertOrReplaceAsync(i);
        }
    }
}
