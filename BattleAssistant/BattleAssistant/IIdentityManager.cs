using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BattleAssistant
{
    public interface IIdentityManager
    {
        Task<IdentityResult> AddUserAsync(IdentityUser user, string password, CancellationToken cancellationToken = default);
        List<IdentityUser> GetAllUsers();
        Task<IList<string>> GetRolesOfUser(IdentityUser user);
        Task<IdentityUser> GetUser(string id);
    }
}