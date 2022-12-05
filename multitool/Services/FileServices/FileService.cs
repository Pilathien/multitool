using Multitool.Services.AccountServices;
using Multitool.Services.CookieServices;
using Multitool.Services.FileServices;
using Multitool.Services.RobloxServices;

namespace Multitool.Services.FileServices;

public class FileService : IFileService
{
    private readonly RobloxService _robloxService;
    private List<Cookie> cookies = new List<Cookie>();
    private List<Account> accounts = new List<Account>();

    public FileService(RobloxService robloxService)
    {
        _robloxService = robloxService;
    }
    
    public void ReadCookies()
    {
        try
        {
            string[] lines = File.ReadAllLines("cookies.txt");
            if (lines.Length > 0)
            {
                foreach (string line in lines)
                {

                    cookies.Add(new Cookie()
                    {
                        cookie = line
                    });
                }
            }
            else
            {
                Console.WriteLine("Cookies file is empty.");
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File \"cookies.txt\" not found... Creating one");
            File.Create("cookies.txt");
        }
    }

    public async Task ReadLogins()
    {
        try
        {
            string[] lines = File.ReadAllLines("combo.txt");
            if (lines.Length > 0)
            {
                foreach (string line in lines)
                {
                    string[] split = line.Split(':');
                    accounts.Add(new Account()
                    {
                        username = split[0],
                        password = split[1]
                    });
                }

                await _robloxService.Login(accounts);
            }
            else
            {
                Console.WriteLine("Logins file is empty.");
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File \"combo.txt\" not found... Creating one");
            File.Create("combo.txt");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine("File \"combo.txt\" is not formatted correctly.");
            Console.WriteLine("Please format it like this: username:password");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}