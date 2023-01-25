using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpService.Domain.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string login, string role, string id, string store);
        string ComputeSha256Hash(string password);

    }
}
