using System.Collections.Generic;
using System.Linq;
using Tone.Shared.Entities;
using Tone.Domain.ValueObjects;
using Tone.Domain.Utils;

namespace Tone.Domain.Entities
{
    public class Singer : Entity
    {
        private readonly IList<Song> _songs;
        private readonly IList<Album> _albums;
        
        public Name Name { get; private set; }
        public string Nationality { get; private set; }
        public string About { get; private set; }
        public string Image { get; private set; }
        public IEnumerable<Song> Songs => this._songs.ToList();
        public IEnumerable<Album> Albums => this._albums.ToList();

        public Singer(Name name, string nationality, string about, string image)
        {
            Name = name;
            Nationality = nationality;
            About = about;
            Image = image;
            _songs = new List<Song>();
            _albums = new List<Album>();
        }

        public void AddSong(Song song)
        {
            if (song.IsValid)
                this._songs.Add(song);
            else
                AddNotification("Song", MessagesUtil.InvalidFileType);
        }

        public void AddAlbum(Album album)
        {
            if (album.IsValid)
                this._albums.Add(album);
            else
                AddNotification("Album", MessagesUtil.InvalidFileType);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}