using Multitool.Services.AccountServices;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Multitool.Services.RobloxServices;

public class RobloxService : IRobloxService
{
    public async Task Login(List<Account> accounts)
    {
        using (var Client = new HttpClient())
        {
            foreach (Account acc in accounts)
            {
                var data = new Dictionary<string, string>
                {
                    {"ctype", "Username"},
                    {"cvalue", acc.username},
                    {"password", acc.password}
                };
            
                var jsonData = JsonConvert.SerializeObject(data);//serialize data into json
                var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");//encoding the data
            
                var request = await Client.PostAsync("https://auth.roblox.com/v2/login", contentData);
                Console.WriteLine(await request.Content.ReadAsStringAsync());
            }
        }
    }
}