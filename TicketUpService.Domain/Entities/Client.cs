using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpService.Domain.Entities
{
    public class Client : Entity
    {
        public Client(string name, string email, string whatsApp, Guid storeId)
        {
            Name = name;
            Email = email;
            WhatsApp = whatsApp;
            CreateDate = DateTime.Now;
            StoreId = storeId;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string WhatsApp { get; private set; }
        public DateTime CreateDate { get; private set; }

        public Guid StoreId { get; private set; }
        public  Store Store { get;private set; }

        public  List<Score> Scores { get; set; }

    }
}
