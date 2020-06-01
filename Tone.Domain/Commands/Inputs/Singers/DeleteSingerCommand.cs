using System;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.singers
{
    public class DeleteSingerCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}