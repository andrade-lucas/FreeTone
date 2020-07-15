using System;

namespace Tone.Domain.Queries.Songs
{
    public class GetSongsQuery
    {
        public Guid Id { get; private set; }
        public string Title { get; set; }
        public string Singer { get; set; }
        public string Album { get; set; }
    }
}