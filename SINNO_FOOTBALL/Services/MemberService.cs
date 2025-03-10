using Newtonsoft.Json;
using System.Text;

namespace SINNO_FOOTBALL.Services;

public interface IMemberService
{
    Task<Document?> GetAll(Document Token);
    Task<Document?> GetInfo(Document Token);
}

public class MemberService : IMemberService
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
