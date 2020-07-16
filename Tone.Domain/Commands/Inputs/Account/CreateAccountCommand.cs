using System;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.Account
{
    public class CreateAccountCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Image { get; set; }
    }
}