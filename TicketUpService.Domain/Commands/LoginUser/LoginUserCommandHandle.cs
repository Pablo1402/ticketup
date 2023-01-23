using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketUpService.Domain.Repository;
using TicketUpService.Domain.Services;
using TicketUpService.Domain.ViewModels;

namespace TicketUpService.Domain.Commands.LoginUser
{
    public class LoginUserCommandHandle : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandle(IAuthService authService, 
            IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user == null)
                return null;

            var token = _authService.GenerateJwtToken(user.Login, user.UserProfile.Name);

            return new LoginUserViewModel(user.Login, token);
        }
    }
}
