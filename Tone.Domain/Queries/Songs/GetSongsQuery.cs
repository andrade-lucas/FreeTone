namespace Tone.Domain.Queries.Songs
{
    public class GetSongsQuery
    {
        public string Title { get; set; }
        public string Singer { get; set; }
        public string Album { get; set; }
        public string AlbumLayer { get; set; }
    }
}