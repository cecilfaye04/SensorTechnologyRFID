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
                await CreateTableAsync<BagInfo>();
                await CreateTableAsync<PierClaimBagScan>();
                await SeedAsync();
        }
        private async Task SeedAsync()
        {
            await InsertAsync(new UserModel { Username = "user", IsLoggedIn = false , Name = String.Empty, AppAccess = String.Empty});
        }
    }
}
