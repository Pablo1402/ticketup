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
    public class ClientRepository : IClientRepository
    {
        private readonly TicketUpContext _context;

        public ClientRepository(TicketUpContext context)
        {
            _context = context;
        }

        public async Task Add(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Client>> GetByStore(Guid storeId)
        {
            return await _context
                .Clients
                .Where(x => x.StoreId == storeId)
                .ToListAsync();
        }
    }
}
