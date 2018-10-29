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
        #region Properties
        HttpClient client;
        #endregion

        #region Construct
        public RestService()
        {
            client = new HttpClient();
            
        }
        #endregion

        #region Api calls
        public Task DoLogin()
        {
            throw new NotImplementedException();

        }
        #endregion

        #region Helper methods

        #endregion
    }
}
