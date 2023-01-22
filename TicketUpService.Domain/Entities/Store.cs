using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpService.Domain.Entities
{
    public class Store : Entity
    {
        public Store(string name, string email)
        {
            Name = name;
            CreateDate = DateTime.Now;
            Email = email;
        }

        public string Name { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Email { get; private set; }


        public  List<User> Users { get; set; }
        public List<Client> Clients { get; set; }

    }
}
