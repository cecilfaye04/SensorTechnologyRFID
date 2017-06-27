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
    public class SqliteService<T> : ISqliteService<T> where T : class, new()
    {
        public async Task InsertUpdate(T entity)
        {
           await App.Connection.InsertOrReplaceWithChildrenAsync(entity);
            //logger.Trace("SqliteService<UserModel> : InsertUpdate, Query : InsertOrReplaceWithChildrenAsync(entity), Result : value")
        }

        public async Task<T> Load()
        {
            var retValue = await App.Connection.Table<T>().FirstOrDefaultAsync();
            //logger.Trace("SqliteService<UserModel> : Load, Query : FirstOrDefaultAsync>(id), Result : value")
            return retValue;
        }

        public async Task<T> Load(string id)
        {
            var retValue = await App.Connection.GetWithChildrenAsync<T>(id);
            //logger.Trace("SqliteService<UserModel> : LoadSpecific, Query : GetWithChildrenAsync<T>(id), Result : value")
            return retValue;
        }
    }
}
