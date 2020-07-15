using System;

namespace Tone.Domain.Queries.Albums
{
    public class GetAlbumByIdQuery
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid GenderId { get; set; }
        public Guid CategoryId { get; set; }
        public string Image { get; set; }
    }
}