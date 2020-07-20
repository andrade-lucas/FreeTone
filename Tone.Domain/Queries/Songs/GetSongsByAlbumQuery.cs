using System;

namespace Tone.Domain.Queries.Songs
{
    public class GetSongsByAlbumQuery
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public Guid SingerId { get; set; }
        public string SingerFirstName { get; set; }
        public string SingerLastName { get; set; }
        public string SingerImage { get; set; }
    }
}