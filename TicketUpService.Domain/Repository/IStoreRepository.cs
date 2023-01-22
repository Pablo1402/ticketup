using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketUpService.Domain.Entities;

namespace TicketUpService.Domain.Repository
{
    public interface IStoreRepository
    {
        Task Create(Store store);
        Task<IList<Store>> GetAll();
    }
}
