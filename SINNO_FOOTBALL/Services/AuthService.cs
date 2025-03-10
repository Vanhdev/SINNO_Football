using Newtonsoft.Json;
using System.Text;

namespace SINNO_FOOTBALL.Services;

public interface IAuthService
{
    Task<Document?> Login(Document loginAccount);
    Task<bool> Logout(Document Token);
}

public class AuthService : IAuthService
{
    public async Task<Document?> Login(Document loginAccount)
    {
        try
        {
            using (var client = new HttpClient())
            {
                string url = $"{Global.baseUrl}/api/Auth/Login";
                var serializeContent = loginAccount.ToString();
                Console.WriteLine(serializeContent);
                var stringContent = new StringContent(serializeContent, Encoding.UTF8, "application/json");
                var apiResponse = await client.PostAsync(url, stringContent);

                Console.WriteLine(serializeContent);
                var x = apiResponse.Content;

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

    public async Task<bool> Logout(Document token)
    {
        try
        {
            using (var client = new HttpClient())
            {
                string url = $"{Global.baseUrl}/api/Auth/Login";
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
