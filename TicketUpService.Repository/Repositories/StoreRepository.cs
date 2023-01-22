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
    public class StoreRepository : IStoreRepository
    {
        private readonly TicketUpContext _context;

        public StoreRepository(TicketUpContext context)
        {
            this._context = context;
        }

        public async Task Create(Store store)
        {
            await _context.Stores.AddAsync(store);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Store>> GetAll()
        {
            var list = await _context.Stores.AsNoTracking().Include("Clients").ToListAsync();
            return list;
        }
    }
}
