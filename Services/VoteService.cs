using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINNO_FC.Services
{
    internal interface IVoteServcie
    {
        Task<Document?> GetVote(Document Token);
        Task<Document?> Vote(Document Token);
    }
    internal class VoteService : IVoteServcie
    {
        public async Task<Document?> GetVote(Document Token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{Global.baseUrl}/api/Vote/Get-active-vote";
                    var serializeContent = Token.ToString();
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

        public async Task<Document?> Vote(Document Token)
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
