using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpService.Domain.Queries.GetClientesByStore
{
    public class GetClientesByStoreQueryResult
    {
        public GetClientesByStoreQueryResult(Guid id, string name, string email, string whatsApp)
        {
            Id = id;
            Name = name;
            Email = email;
            WhatsApp = whatsApp;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string WhatsApp { get; private set; }
    }
}
