using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpService.Domain.Entities
{
    public class Entity
    {

        public Entity()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }

        public bool Equals(Entity entity)
        {
            return Id == entity.Id;
        }
    }
}
