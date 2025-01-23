using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.Domain.Entities;
using MediatR;

namespace AuthService.Application.Auth.Queries
{
    public class GetUserQuery : IRequest<IEnumerable<User>>
    {
        // Add filters or criteria if necessary
        //public Guid UserId { get; set; }
    }
}
