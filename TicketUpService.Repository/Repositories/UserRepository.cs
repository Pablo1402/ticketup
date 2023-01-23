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
    public class UserRepository : IUserRepository
    {
        private readonly TicketUpContext _context;

        public UserRepository(TicketUpContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context
                .Users
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string login, string passwordHash)
        {

            return await _context
                .Users
                .Include("UserProfile")
                .SingleOrDefaultAsync(x => x.Login == login && x.Password == passwordHash);
        }
    }
}
