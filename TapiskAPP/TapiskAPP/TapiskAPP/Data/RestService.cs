using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TapiskAPP.Models;
using TapiskAPP.Services;

namespace TapiskAPP.Data
{
    public class RestService : IRestService
    {
        #region Fields
        static HttpClient client;
        string baseUrl = "http://farmtapiskapi.herokuapp.com/";
        #endregion

        #region Construct
        public RestService()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                client.Timeout = TimeSpan.FromSeconds(100);
            }
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

        public async Task<bool> DoLogin(string username, string password, bool remember = false, ISqLiteService sqLiteService = null)
        {
            var uri = new Uri(string.Format(baseUrl+"user_token", string.Empty));
            bool isSuccess = false;
            try
            {
                var requestJson = JsonConvert.SerializeObject(
                    new { auth = 
                        new { username  = username,
                            password = password,
                            }
                        }
                    );
                var content = await Task.Run(()=> new StringContent(requestJson, Encoding.UTF8, "application/json"));

                HttpResponseMessage response = null;
                
                response = await Task.Run(() => client.PostAsync(uri, content));

                if (response.IsSuccessStatusCode)
                {
                    isSuccess = true;
                    // TODO: Save token [Done]
                    
                    var responseJson = await Task.Run(async()=> (JObject)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync()));
                    var token = responseJson.SelectToken("jwt").ToString();
                    AssignToken(token);
                    Usuario userData = await Task.Run(() => GetCurrentUser());
                    if (userData != null)
                    {
                        Models.SqLiteModels.User sqliteUser = new Models.SqLiteModels.User();
                        sqliteUser.UserId = userData.Id;
                        sqliteUser.Name = userData.Empleado.Nombre;
                        sqliteUser.LastName = userData.Empleado.Apellido;
                        sqliteUser.Token = token;
                        sqliteUser.RememberToken = remember ? 1 : 0;
                        sqliteUser.CreatedToken = DateTime.Now.Ticks;
                        // TODO: Guardar datos de cargo en local. actualizar tapisk.db
                        sqliteUser.PositionId = 0;
                        sqliteUser.PositionName = "not implemented yet";
                        var IsRemember = await new SqLiteService(sqLiteService).RememberUser(sqliteUser);
                        if (!IsRemember) Debug.WriteLine("          It seems that it could not be saved");
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return isSuccess;
        }

        public async Task<Usuario> GetCurrentUser()
        {
            var uri = new Uri(string.Format(baseUrl + "users/current", string.Empty));
            Usuario usuario = null;
            try
            {
                HttpResponseMessage response = null;

                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    usuario = await Task.Run<Usuario>(()=> JsonConvert.DeserializeObject<Usuario>(stringContent));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return usuario;
        }

        public Task<Empleado> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Empleado>> GetEmployees()
        {
            List<Empleado> employees = null;
            var uri = new Uri(string.Format(baseUrl + "employees",string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<List<Empleado>>(content);
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error: " + ex.Message);
            }
            return employees;
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
        public void AssignToken(string token, string type = "Bearer")
        {
            if (client.DefaultRequestHeaders.Authorization == null)
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(type, token);
            }
        }
        #endregion
    }


}

