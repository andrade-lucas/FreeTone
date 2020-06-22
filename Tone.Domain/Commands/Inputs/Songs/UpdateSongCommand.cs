using System;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs.Songs
{
    public class UpdateSongCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid SingerId { get; set; }
        public Guid AlbumId { get; set; }
        public string Url { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}