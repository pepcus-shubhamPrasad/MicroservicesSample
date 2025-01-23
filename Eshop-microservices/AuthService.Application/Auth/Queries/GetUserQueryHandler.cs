using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.Domain.Entities;
using AuthServices.Infrastructure;
using MediatR;

namespace AuthService.Application.Auth.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IEnumerable<User>>
    {
        private readonly InMemoryDatabase _database;

        public GetUserQueryHandler(InMemoryDatabase database)
        {
            _database = database;
        }

        public Task<IEnumerable<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = _database.GetAllUsers();
            return Task.FromResult(users);
        }
    }
}
