using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketUpService.Domain.Entities;
using TicketUpService.Domain.Repository;

namespace TicketUpService.Domain.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, CreateClientCommandResult>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientCommandHandler(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public async Task<CreateClientCommandResult> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client(request.Name,
                request.Email,
                request.WhatsApp,
                request.StoreId.Value);

            await _clientRepository.Add(client);

            return new CreateClientCommandResult(client.Name,client.Email,client.WhatsApp,client.Id);
        }
    }
}
