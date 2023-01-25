using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketUpService.Domain.Repository;

namespace TicketUpService.Domain.Queries.GetClientesByStore
{
    internal class GetClientesByStoreQueryHandler : IRequestHandler<GetClientesByStoreQuery, List<GetClientesByStoreQueryResult>>
    {
        private readonly IClientRepository _clientRepository;

        public GetClientesByStoreQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<GetClientesByStoreQueryResult>> Handle(GetClientesByStoreQuery request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetByStore(request.StoreId);

            var data = new List<GetClientesByStoreQueryResult>();

            clients.ToList().ForEach(x => data.Add(new GetClientesByStoreQueryResult(x.Id,
                x.Name,
                x.Email,
                x.WhatsApp)));
            return data;

        }
    }
}
