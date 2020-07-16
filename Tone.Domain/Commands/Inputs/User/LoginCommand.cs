using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.User
{
    public class LoginCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}