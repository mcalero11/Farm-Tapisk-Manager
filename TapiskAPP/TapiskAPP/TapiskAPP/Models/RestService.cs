using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TapiskAPP.Services;

namespace TapiskAPP.Models
{
    public class RestService : IRestService
    {
        #region Fields
        HttpClient client;
        #endregion

        #region Construct
        public RestService()
        {
            client = new HttpClient();
            
        }
        #endregion

        #region Api calls
        public Task<bool> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePosition(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
        
        public Task DoLogin()
        {
            throw new NotImplementedException();

        }

        public Task<Token> DoLogin(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public Task<Empleado> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Empleado>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<Cargo> GetPosition(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cargo>> GetPositions()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEmployee(Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SavePosition(Cargo cargo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveUser(Usuario empleado)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEmployee(Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePosition(Cargo cargo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(Usuario user)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Helper methods

        #endregion
    }
}
