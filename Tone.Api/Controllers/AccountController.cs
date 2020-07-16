using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tone.Api.Services;
using Tone.Domain.Commands.Handlers;
using Tone.Domain.Commands.Inputs.User;
using Tone.Domain.Commands.Outputs;
using Tone.Domain.Queries.Users;
using Tone.Domain.Repositories;
using Tone.Domain.Services;
using Tone.Shared.Commands;

namespace Tone.Api.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly AccountHandler _handler;

        public AccountController(IUserRepository userRepository, IEmailService emailService)
        {
            this._userRepository = userRepository;
            this._emailService = emailService;
            this._handler = new AccountHandler(_userRepository, _emailService);
        }

        [HttpPost]
        [Route("v1/account/login")]
        public ICommandResult Login([FromBody]LoginCommand command)
        {
            ICommandResult loginResult = _handler.Handle(command);
            if (loginResult.Status == false)
                return loginResult;

            UserAuthQuery user = (UserAuthQuery)loginResult.Data;
            string token = TokenService.GenerateToken(user);
            object data = new { token = token, user = user };
            return new CommandResult(loginResult.Status, loginResult.Message, data: data);
        }

        [HttpPost]
        [Route("v1/account/register")]
        public ICommandResult Register([FromBody]CreateUserCommand command)
        {
            return _handler.Handle(command);
        }
    }
}