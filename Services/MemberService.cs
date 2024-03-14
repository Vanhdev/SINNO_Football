using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINNO_FC.Services
{
    internal interface IMemberServcie
    {
        Task<Document?> GetAll(Document Token);
        Task<Document?> GetInfo(Document Token);
    }
    internal class MemberService : IMemberServcie
    {
        public async Task<Document?> GetAll(Document Token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{Global.baseUrl}/api/Member/Get-all";
                    var serializeContent = JsonConvert.SerializeObject(Token);
                    Console.WriteLine(serializeContent);
                    var stringContent = new StringContent(serializeContent, Encoding.UTF8, "application/json");
                    var apiResponse = await client.PostAsync(url, stringContent);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string body = await apiResponse.Content.ReadAsStringAsync();

                        var response = Document.Parse(body);

                        return response;
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

        public async Task<Document?> GetInfo(Document Token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{Global.baseUrl}/api/Member/Get-info";
                    var serializeContent = JsonConvert.SerializeObject(Token);
                    Console.WriteLine(serializeContent);
                    var stringContent = new StringContent(serializeContent, Encoding.UTF8, "application/json");
                    var apiResponse = await client.PostAsync(url, stringContent);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string body = await apiResponse.Content.ReadAsStringAsync();

                        var response = Document.Parse(body);

                        return response;
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
    }
}
