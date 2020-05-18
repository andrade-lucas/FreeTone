using System;
using Tone.Shared.Entities;

namespace Tone.Domain.Entities
{
    public class Song : Entity
    {
        public string Title { get; private set; }
        public string Lyrics { get; private set; }
        public DateTime PublishedDate { get; private set; }
        public string Singer { get; private set; }
    }
}
