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
    public interface ISqliteService<T> where T : class,new()
    {
        Task<T> Load();
        Task<T> Load(string id);
        Task InsertUpdate(T entity);
    }
}
