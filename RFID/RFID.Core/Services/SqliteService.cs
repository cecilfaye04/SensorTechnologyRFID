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
        }

        public async Task<T> Load()
        {

            return await App.Connection.Table<T>().FirstOrDefaultAsync();
        }

        public async Task<T> Load(string id)
        {
            return await App.Connection.GetWithChildrenAsync<T>(id);
        }
    }
}
