using LgpDuvidas.Models;
using System.Threading.Tasks;

namespace LgpDuvidas.Services
{
    public interface IAuthService
    {
        Task<UserModel> Register(UserModel input);
        Task<UserModel> Login(UserModel input);
    }
}
