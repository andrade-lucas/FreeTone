using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tone.Shared.Commands;

namespace Tone.Api.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        [HttpPost]
        [Route("v1/account/login")]
        public ICommandResult Login()
        {
            return null;
        }

        [HttpPost]
        [Route("v1/account/register")]
        public ICommandResult Register()
        {
            return null;
        }
    }
}