using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketUpService.Domain.Entities;

namespace TicketUpService.Domain.Repository
{
    public interface IClientRepository
    {
        Task<IList<Client>> GetByStore(Guid storeId);
        Task Add(Client client);
    }
}
