using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFID.Core.Models;

namespace RFID.Core.Services
{
    public class SqliteService : ISqliteService
    {
        public async Task<UserModel> LoadUserAsync()
        {
            return await App.Connection.Table<UserModel>().FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(UserModel i)
        {
            await App.Connection.InsertOrReplaceAsync(i);
        }
    }
}
