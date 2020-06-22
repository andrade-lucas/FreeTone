using System;

namespace Tone.Domain.Queries.Songs
{
    public class GetSongByIdQuery
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid SingerId { get; set; }
        public Guid AlbumId { get; set; }
        public string Url { get; set; }
        public int DownloadCounter { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}