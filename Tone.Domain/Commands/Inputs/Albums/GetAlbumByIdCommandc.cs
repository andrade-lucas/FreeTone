using System;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.Albums
{
    public class GetAlbumById : ICommand
    {
        public Guid Id { get; set; }
    }
}