using Microsoft.AspNetCore.Mvc;
using Tone.Domain.Commands.Handlers;
using Tone.Domain.Commands.Inputs.User;
using Tone.Domain.Repositories;
using Tone.Shared.Commands;

namespace Tone.Api.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserHandler _handler;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
            _handler = new UserHandler(_repository);
        }

        [HttpPost]
        public ICommandResult Create([FromBody]CreateUserCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("users")]
        public ICommandResult Update([FromBody]UpdateUserCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("users/{id}")]
        public ICommandResult Delete(DeleteUserCommand command)
        {
            return _handler.Handle(command);
        }
    }
}