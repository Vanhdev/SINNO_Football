using Newtonsoft.Json;
using SINNO_FC.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINNO_FC.Services
{
    internal interface IAuthService
    {
        Task<LoginResponse> Login(LoginModel loginAccount);
    }

    internal class AuthService : IAuthService
    {
        private string _baseUrl = Global.baseUrl;
        public async Task<LoginResponse> Login(LoginModel loginAccount)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Auth/Login";
                    var serializeContent = JsonConvert.SerializeObject(loginAccount);
                    Console.WriteLine(serializeContent);
                    var stringContent = new StringContent(serializeContent, Encoding.UTF8, "application/json");
                    var apiResponse = await client.PostAsync(url, stringContent);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string body = await apiResponse.Content.ReadAsStringAsync();

                        LoginResponse token = JsonConvert.DeserializeObject<LoginResponse>(body);

                        return token;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
        public async Task<bool> Logout(TokenModel token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Auth/Login";
                    var serializeContent = JsonConvert.SerializeObject(token);
                    Console.WriteLine(serializeContent);
                    var stringContent = new StringContent(serializeContent, Encoding.UTF8, "application/json");
                    var apiResponse = await client.PostAsync(url, stringContent);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
            }
        }
    }
}
