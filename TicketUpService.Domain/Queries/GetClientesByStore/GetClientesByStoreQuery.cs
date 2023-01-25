using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpService.Domain.Queries.GetClientesByStore
{
    public class GetClientesByStoreQuery : IRequest<List<GetClientesByStoreQueryResult>>
    {
        public Guid StoreId { get; private set; }

        public GetClientesByStoreQuery(string storeId)
        {
            StoreId = new Guid(storeId);
        }
    }
}
