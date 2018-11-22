using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TapiskAPP.Data;
using TapiskAPP.Models;

namespace TapiskAPP.Services
{
    public interface IRestService
    {

        #region Get Calls

        Task<Usuario> GetCurrentUser();
        Task<Response> GetList<T>(string controller,
                                  string[] parameters,
                                  string prefix = "");
        Task<Response> GetByID<T>(string controller,
                                  object id,
                                  string prefix = "");
        #endregion
        #region Post Calls
        Task<bool> DoLogin(string username, string password, bool remember, ISqLiteService sqLiteService);
        Task<Response> Post<T>(string controller,
                               T model,
                               string prefix = "");
        
        #endregion
        #region Put Calls
        Task<Response> Put<T>(string controller,
                              T model,
                              object id,
                              string prefix = "");
        #endregion
        #region Delete Calls
        Task<Response> Delete(string controller,
                              object id,
                              string prefix = "");
        #endregion
        
    }
}
