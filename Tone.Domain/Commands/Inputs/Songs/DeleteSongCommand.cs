using System;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.Songs
{
    public class DeleteSongCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}