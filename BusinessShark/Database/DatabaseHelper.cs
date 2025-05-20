using System.Data.SQLite;

namespace BusinessShark.Database
{
    internal static class DatabaseHelper
    {
        public static SQLiteConnection GetSqlConnection()
        {
            return new SQLiteConnection("Data Source=Database\\BusinessShark.db");
        }
    }
}
