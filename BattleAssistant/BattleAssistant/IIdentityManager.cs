using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace BattleAssistant
{
    public interface IIdentityManager
    {
        Task<IdentityResult> AddUserAsync(IdentityUser user, string password, CancellationToken cancellationToken = default);
    }
}