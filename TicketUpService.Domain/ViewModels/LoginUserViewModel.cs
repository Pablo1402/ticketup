using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpService.Domain.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string login, string token)
        {
            Login = login;
            Token = token;
        }

        public string Login { get; private set; }
        public string Token { get; private set; }
    }
}
