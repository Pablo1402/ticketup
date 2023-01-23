using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketUpService.Domain.Entities;

namespace TicketUpService.Domain.Repository
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetUserByEmailAndPasswordAsync(string login, string passwordHash);
        Task AddAsync(User user);
    }
}
