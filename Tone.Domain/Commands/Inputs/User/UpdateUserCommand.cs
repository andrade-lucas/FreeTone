using System;
using Tone.Domain.Enums;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.User
{
    public class UpdateUserCommand : ICommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EUserStatus Status { get; set; }
        public DateTime Birthdate { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Image { get; set; }
    }
}