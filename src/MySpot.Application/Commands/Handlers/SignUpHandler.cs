using MySpot.Api.Services;
using MySpot.Application.Abstractions;
using MySpot.Application.Security;
using MySpot.Core.Entities;
using MySpot.Core.Repositories;

namespace MySpot.Application.Commands.Handlers
{
    internal sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordManager _passwordManager;
        private readonly IClock _clock;

        public SignUpHandler(IUserRepository userRepository,IPasswordManager passwordManager,IClock clock)
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;
            _clock = clock;
        }
        public async Task HandleAsync(SignUp command)
        {
            var securedPassword = _passwordManager.Secure(command.Password);
            var user = new User(command.UserId, command.Email, command.Username ,
                command.Password, command.FullName, command.Role, _clock.Current());
        }
    }
}
