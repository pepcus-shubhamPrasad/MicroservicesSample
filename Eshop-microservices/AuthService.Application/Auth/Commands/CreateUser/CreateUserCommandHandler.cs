using System;
using System.Collections.Generic;
using AuthService.Domain.Entities;
using AuthServices.Infrastructure;
using MediatR;

namespace AuthService.Application.Auth.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly InMemoryDatabase _database;

        public CreateUserCommandHandler(InMemoryDatabase database)
        {
            _database = database;
        }

        public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Email = request.Email,
                FullName = request.FullName
            };

            _database.AddUser(user);
            return Task.FromResult(user.Id);
        }
    }
}
