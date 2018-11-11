using SQLite.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using TapiskAPP.Models.SqLiteModels;
using TapiskAPP.Services;

namespace TapiskAPP.Data
{
    public class SqLiteService
    {
        static SQLiteConnection dbConnection;
        public SqLiteService(ISqLiteService sqLiteService = null)
        {
            if (dbConnection == null)
            {
                dbConnection = sqLiteService.CreateConnection();
            }
        }
        public async Task<bool> RememberUser(User user)
        {
            dbConnection.DeleteAll<User>();
            var rowsInserted = await Task.Run(()=>dbConnection.Insert(user));
            var success = rowsInserted > 0;
            return success;
        }
        public async Task<bool> DisposeUser()
        {
            var users = await GetUsers();
            if (users.Count > 0)
            {
                if (users[0].RememberToken != 0)
                {
                    return false;
                }
                dbConnection.DeleteAll<User>();
            }
            return true;
        }
        public async Task<List<User>> GetUsers()
        {
            var users = await Task.Run(() => dbConnection.Query<User>("select * from User"));
            return users;
        }
        public async Task<User> RetrieveUser()
        {
            var users = await GetUsers();
            if (users.Count > 0)
            {
                return users[0];
            }
            return null;
        }
        public async Task<int> Logout()
        {
            return await Task.Run(()=>dbConnection.DeleteAll<User>());
        }
    }
}
