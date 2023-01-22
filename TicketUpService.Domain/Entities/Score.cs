using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpService.Domain.Entities
{
    public class Score : Entity
    {
        public Score(string note, Guid clientId, Guid userCreateId)
        {
            ScoreDate = DateTime.Now;
            Note = note;
            Rescued = false;
            RescuedDate = null;
            ClientId = clientId;
            UserCreateId = userCreateId;
        }

        public DateTime ScoreDate { get; private set; }
        public string Note { get; private set; }
        public bool Rescued { get; private set; }
        public DateTime? RescuedDate { get; private set; }

        public Guid ClientId { get; private set; }
        public Client Client { get; private set; }

        public Guid UserCreateId { get; private set; }
        public User UserCreate { get; private set; }

        public void Rescue()
        {
            Rescued = true;
            RescuedDate = DateTime.Now;
        }
    }
}
