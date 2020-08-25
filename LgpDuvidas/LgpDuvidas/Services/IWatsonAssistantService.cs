using LgpDuvidas.Models;
using System.Threading.Tasks;

namespace LgpDuvidas.Services
{
    public interface IWatsonAssistantService
    {
        Task<WatsonMessage> Send(WatsonMessage input);
    }
}
