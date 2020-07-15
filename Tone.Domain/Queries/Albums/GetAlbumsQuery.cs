using System;

namespace Tone.Domain.Queries.Albums
{
    public class GetAlbumsQuery
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}