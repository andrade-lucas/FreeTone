using System;
using Microsoft.AspNetCore.Mvc;
using Tone.Domain.Commands.Handlers;
using Tone.Domain.Commands.Inputs.User;
using Tone.Domain.Repositories;
using Tone.Domain.Services;
using Tone.Shared.Commands;

namespace Tone.Api.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly IEmailService _emailService;
        private readonly UserHandler _handler;

        public UsersController(IUserRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
            _handler = new UserHandler(_repository, _emailService);
        }

        [HttpPost]
        [Route("v1/users")]
        public ICommandResult Create([FromBody]CreateUserCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/users/profile")]
        public ICommandResult Update([FromBody]UpdateUserCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/users/{id}")]
        public ICommandResult Delete(DeleteUserCommand command)
        {
            return _handler.Handle(command);
        }
    }
}