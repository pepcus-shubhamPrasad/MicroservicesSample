using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AuthService.Application.Auth.Commands.UserLogin
{
    public class LoginUserCommand : IRequest<string>
    {
        public string Username { get; set; }
        //public string Password { get; set; }
    }
}
