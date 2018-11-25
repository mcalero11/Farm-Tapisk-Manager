using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
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
        #endregion

        #region Construct
        public RestService(string baseUrl = "http://farmtapiskapi.herokuapp.com/")
        {
            if (client == null)
            {
                client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;
                client.Timeout = TimeSpan.FromSeconds(100);
                client.BaseAddress = new Uri(baseUrl);
            }
        }
        #endregion

        #region Api calls
        
        public async Task<bool> DoLogin(string username, string password, bool remember = false, ISqLiteService sqLiteService = null)
        {
            var url = string.Format("user_token", string.Empty);
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
                
                response = await Task.Run(() => client.PostAsync(url, content));

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
                        // TODO: Guardar datos de cargo en local. 
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
            var url = string.Format("users/current", string.Empty);
            Usuario usuario = null;
            try
            {
                HttpResponseMessage response = null;

                response = await client.GetAsync(url);

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

        #endregion

        #region Generic Api calls
        public async Task<Response> GetList<T>(string controller, string[] parameters = null, string prefix = "")
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string args = string.Empty;
                if (parameters != null)
                {
                    foreach (string item in parameters)
                    {
                        args += "/" + item;
                    }
                }
                var url = $"{prefix}{controller}{args}";
                var result = await client.GetAsync(url);
                if (!result.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "An error has been occurred while trying to retrieve the data",
                        Result = null,
                    };
                }
                string stringContent = await result.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<T>>(stringContent);
                return new Response
                {
                    IsSuccess = true,
                    Message = result.ReasonPhrase,
                    Result = list,

                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Result = null,
                };
            }
        }

        public async Task<Response> GetByID<T>(string controller, object id, string prefix = "")
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url = $"{prefix}{controller}/{id}";
                var result = await client.GetAsync(url);
                if (!result.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "An error has been occurred while trying to retrieve the data",
                        Result = null,
                    };
                }
                string stringContent = await result.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<T>(stringContent);
                return new Response
                {
                    IsSuccess = true,
                    Message = result.ReasonPhrase,
                    Result = obj,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Result = null,
                };
            }
        }

        public async Task<Response> Post<T>(string controller, T model, string prefix = "")
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url = $"{prefix}{controller}";
                string jsonObject = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, content);
                if (!result.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "An error has been occurred while trying to save the data",
                        Result = null,
                    };
                }
                string stringContent = await result.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<T>(stringContent);
                return new Response
                {
                    IsSuccess = true,
                    Message = result.ReasonPhrase,
                    Result = obj,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Result = null,
                };
            }
        }

        public async Task<Response> Put<T>(string controller, T model, object id, string prefix = "")
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url = $"{prefix}{controller}/{id}";
                string jsonObject = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(url, content);
                if (!result.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "An error has been occurred while trying to save the data",
                        Result = null,
                    };
                }
                string stringContent = await result.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<T>(stringContent);
                return new Response
                {
                    IsSuccess = true,
                    Message = result.ReasonPhrase,
                    Result = obj,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Result = null,
                };
            }
        }

        public async Task<Response> Delete(string controller, object id, string prefix = "")
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url = $"{prefix}{controller}/{id}";
                var result = await client.DeleteAsync(url);
                string stringContent = await result.Content.ReadAsStringAsync();
                if (!result.IsSuccessStatusCode)
                {
                    var error = JsonConvert.DeserializeObject<Response>(stringContent);
                    error.IsSuccess = false;
                    return error;
                }
                return new Response
                {
                    IsSuccess = true,
                    Message = result.ReasonPhrase,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Result = null,
                };
            }
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

