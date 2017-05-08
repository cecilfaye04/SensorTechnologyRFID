using RFID.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Core.Interfaces
{
    public interface ISqliteService
    {
        Task UpdateAsync(UserModel i);
        Task<UserModel> LoadUserAsync();
    }
}
