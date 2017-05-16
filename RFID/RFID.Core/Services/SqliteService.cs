using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFID.Core.Models;
using RFID.Core.Interfaces;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using SQLiteNetExtensionsAsync.Extensions;

namespace RFID.Core.Services
{
    public class SqliteService: ISqliteService
    {


        public async Task<BagInfo> LoadBagInfoAsync(string bagtag)
        {
            return await App.Connection.GetWithChildrenAsync<BagInfo>(bagtag);
            //return await App.Connection.Table<BagInfo>().FirstOrDefaultAsync();
        }

        public async Task<List<BagInfo>> GetBagInfoAsync()
        {

            return await App.Connection.GetAllWithChildrenAsync<BagInfo>();
        }

        public async Task<List<PierClaimBagScan>> LoadPierClaimBagScan()
        {
            return await App.Connection.Table<PierClaimBagScan>().ToListAsync();
        }

        public async Task<UserModel> LoadUserAsync()
        {
            return await App.Connection.Table<UserModel>().FirstOrDefaultAsync();
        }

        public async Task UpdateBagInfoAsync(BagInfo i)
        {

            await App.Connection.InsertOrReplaceWithChildrenAsync(i);
        }

        public async Task UpdatePierClaimBagScan(PierClaimBagScan i)
        {
            await App.Connection.InsertOrReplaceAsync(i);
        }

        public Task UpdatePierClaimLocationAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserAsync(UserModel i)
        {
            await App.Connection.InsertOrReplaceAsync(i);
        }


    }


}
