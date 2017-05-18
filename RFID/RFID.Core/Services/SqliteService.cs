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
            var x = await App.Connection.GetWithChildrenAsync<BagInfo>(bagtag);
            //var z = await App.Connection.Table<BagInfo>().FirstOrDefaultAsync();
            //var xz = await App.Connection.Table<BagInfo>().FirstAsync();
            //var y = await App.Connection.GetAllWithChildrenAsync<BagInfo>(xs => xs.Bagtag == bagtag);
            return x;
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
            await App.Connection.InsertOrReplaceWithChildrenAsync(i,true);
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
