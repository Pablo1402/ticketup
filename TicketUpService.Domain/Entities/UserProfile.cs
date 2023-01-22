using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpService.Domain.Entities
{
    public class UserProfile : Entity
    {
        public UserProfile(string name)
        {
            Name = name;
        }

        public string Name { get; private  set; }

        public List<User> Users { get; set; }
    }
}
