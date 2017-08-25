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
using MvvmCross.Platform;

namespace RFID.Core.Services
{
    public class SqliteService<T> : ISqliteService<T> where T : class, new()
    {
        ILogService _logger;

        public SqliteService()
        {
            _logger = Mvx.Resolve<ILogService>();
        }

        public async Task InsertUpdate(T entity)
        {
            _logger.Trace("SqliteService<UserModel> : InsertUpdate Start");
            await App.Connection.InsertOrReplaceWithChildrenAsync(entity);
        }

        public async Task<T> Load()
        {
            _logger.Trace("SqliteService<UserModel> :  Load Start");
            var retValue = await App.Connection.Table<T>().FirstOrDefaultAsync();
            return retValue;
        }

        public async Task<T> Load(string id)
        {
            _logger.Trace("SqliteService<UserModel> :  Load(string id) Start");
            var retValue = await App.Connection.GetWithChildrenAsync<T>(id);
            return retValue;
        }
    }
}
