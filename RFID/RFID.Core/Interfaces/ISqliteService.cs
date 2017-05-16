using RFID.Core.Models;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Interfaces
{
    public interface ISqliteService
    {
        Task UpdateUserAsync(UserModel i);
        Task<UserModel> LoadUserAsync();
        Task UpdateBagInfoAsync(BagInfo i);
        Task<BagInfo> LoadBagInfoAsync(String bagtag);
        Task<List<BagInfo>> GetBagInfoAsync();
        Task UpdatePierClaimLocationAsync();
        Task UpdatePierClaimBagScan(PierClaimBagScan i);
        Task<List<PierClaimBagScan>> LoadPierClaimBagScan();




    }
}
