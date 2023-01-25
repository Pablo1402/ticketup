using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpService.Domain.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<CreateClientCommandResult>
    {
        public CreateClientCommand(string name, string email, string whatsApp)
        {
            Name = name;
            Email = email;
            WhatsApp = whatsApp;
        }

        public Guid? StoreId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string WhatsApp { get; private set; }

        public void SetStore(string storeId)
        {
            this.StoreId = new Guid(storeId);
        }
    }
}
