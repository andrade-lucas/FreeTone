using System;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.User
{
    public class DeleteUserCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}