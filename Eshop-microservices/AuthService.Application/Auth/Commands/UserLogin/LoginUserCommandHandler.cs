using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentications;
using AuthServices.Infrastructure;
using MediatR;

namespace AuthService.Application.Auth.Commands.UserLogin
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly JwtTokenService _jwtTokenService;
        private readonly InMemoryDatabase _database;

        public LoginUserCommandHandler(JwtTokenService jwtTokenService, InMemoryDatabase database)
        {
            _jwtTokenService = jwtTokenService;
            _database = database;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = _database.GetAllUsers().FirstOrDefault(u =>
                u.Username == request.Username);

            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials");

            var roles = new List<string> { "User" };

            return _jwtTokenService.GenerateToken(user.Id.ToString(), user.Username, roles);
        }
    }
}
