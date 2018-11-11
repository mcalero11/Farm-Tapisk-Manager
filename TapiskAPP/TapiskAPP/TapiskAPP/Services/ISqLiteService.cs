using SQLite.Net;

namespace TapiskAPP.Services
{
    public interface ISqLiteService
    {
        SQLiteConnection CreateConnection();
    }
}
