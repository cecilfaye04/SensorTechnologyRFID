using SQLite.Net.Attributes;

namespace RFID.Core.Models
{
    [Table("UserModel")]
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string Username { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
