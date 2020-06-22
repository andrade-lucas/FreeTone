using System;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.Albums
{
    public class EditAlbumCommand : ICommand
    {
        public string Title { get; set; }
        public Guid GenderId { get; set; }
        public Guid CategoryId { get; set; }
        public string Image { get; set; }
    }
}