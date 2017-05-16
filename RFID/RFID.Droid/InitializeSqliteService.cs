using System.Threading.Tasks;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using RFID.Core;
using RFID.Core.Services;
using RFID.Core.Interfaces;

namespace RFID.Droid
{
    public class InitializeSqliteService : IInitilializeSqliteService
    {
        public async Task InitializeAsync()
        {
            var _db = new SqliteDatabase(GetConnection);
            if (!DatabaseExists())
                await _db.InitializeAsync();
            App.Connection = _db;
        }

        private static bool DatabaseExists()
        {
            return File.Exists(GetDatabasePath());
        }

        private static string GetDatabasePath()
        {
            return System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "RFIDXamarin14.db3");
        }

        private static SQLiteConnectionWithLock GetConnection()
        {
            return new SQLiteConnectionWithLock(new SQLitePlatformAndroid(), new SQLiteConnectionString(GetDatabasePath(), false));
        }
    }
}