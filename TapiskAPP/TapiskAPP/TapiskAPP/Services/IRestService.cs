using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TapiskAPP.Models;

namespace TapiskAPP.Services
{
    public interface IRestService
    {
        #region GET
        Task<List<Empleado>> GetEmployees();
        Task<Empleado> GetEmployee(int id);
        Task<List<Usuario>> GetUsers();
        Task<Usuario> GetUser(int id);
        Task<Usuario> GetCurrentUser();
        Task<List<Cargo>> GetPositions();
        Task<Cargo> GetPosition(int id);
        #endregion

        #region POST
        Task<bool> DoLogin(string username, string password, bool remember, ISqLiteService sqLiteService);
        Task<bool> SaveEmployee(Empleado empleado);
        Task<bool> SaveUser(Usuario empleado);
        Task<bool> SavePosition(Cargo cargo);
        #endregion

        #region PUT
        Task<bool> UpdateEmployee(Empleado empleado);
        Task<bool> UpdateUser(Usuario user);
        Task<bool> UpdatePosition(Cargo cargo);
        #endregion

        #region DELETE
        Task<bool> DeleteEmployee(int id);
        Task<bool> DeleteUser(int id);
        Task<bool> DeletePosition(int id);
        #endregion



    }
}
