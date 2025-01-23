using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AuthService.Application.Auth.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
