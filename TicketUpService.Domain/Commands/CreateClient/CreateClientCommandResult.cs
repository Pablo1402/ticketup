using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpService.Domain.Commands.CreateClient
{
    public class CreateClientCommandResult
    {
        public CreateClientCommandResult(string name, string email, string whatsApp, Guid id)
        {
            Name = name;
            Email = email;
            WhatsApp = whatsApp;
            Id = id;
        }
        public Guid Id { get; private set; }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string WhatsApp { get; private set; }
    }
}
