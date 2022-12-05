using Multitool.Services.AccountServices;

namespace Multitool.Services.RobloxServices;

public interface IRobloxService
{
    Task Login(List<Account> accounts);
}