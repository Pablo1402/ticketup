using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketUpService.Domain.Entities;
using TicketUpService.Domain.Repository;
using TicketUpService.Repository.Contexts;

namespace TicketUpService.Repository.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly TicketUpContext _context;

        public UserProfileRepository(TicketUpContext context)
        {
            this._context = context;
        }
        public async Task Create(UserProfile profile)
        {
            await _context.AddAsync(profile);
            _context.SaveChanges();
        }

        public async Task<UserProfile> GetById(Guid id)
        {
            return await _context.UserProfiles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
