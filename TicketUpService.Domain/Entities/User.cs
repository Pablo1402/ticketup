using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpService.Domain.Entities
{
    public class User : Entity
    {
        public User(string name, string telephone, string login, string password, Guid storeId)
        {
            Name = name;
            Telephone = telephone;
            Login = login;
            Password = password;
            StoreId = storeId;
        }

        public string Name {  get; private set; }
        public string Telephone {  get; private set; }
        public string Login {  get; private set; }
        public string Password {  get; private set; }


        public Guid UserProfileId {  get; private set; }
        public UserProfile UserProfile {  get; private set; }

        public Guid StoreId {  get; private set; }
        public Store Store {  get; private set; }

        public List<Score> Scores { get; set; }

        public void SetProfile(Guid userProfile)
        {
            this.UserProfileId = userProfile;
        }
    }
}
