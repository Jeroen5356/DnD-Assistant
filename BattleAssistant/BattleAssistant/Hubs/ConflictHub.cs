using BattleAssistant.ViewModels;
using DataLayer.Entites;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BattleAssistant.Hubs
{
    public class ConflictHub : Hub
    {
        private readonly DataContext _context;

        public ConflictHub(DataContext context)
        {
            _context = context;
        }

        public async Task<ConflictViewModel> GetConflict(Guid conflictId)
        {
            var conflict = await _context.Conflict.FirstOrDefaultAsync(c => c.Id == conflictId);
            if (conflict != null)
            {
                return new ConflictViewModel(conflict);
            }
            return new ConflictViewModel();
        }
    }
}
