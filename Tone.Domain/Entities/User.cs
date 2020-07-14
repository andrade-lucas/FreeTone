using System;
using Tone.Domain.ValueObjects;
using Tone.Shared.Entities;
using Tone.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Tone.Domain.Entities
{
    public class User : Entity
    {
        private readonly IList<Album> _albums;
        private readonly IList<Song> _songs;

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public EUserStatus Status { get; private set; }
        public DateTime? Birthdate { get; private set; }
        public Address Address { get; private set; }
        public string Image { get; private set; }
        public IEnumerable<Album> Albums => this._albums.ToList();
        public IEnumerable<Song> Songs => this._songs.ToList();
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public User(Name name, Email email, Password password, DateTime? birthdate, Address address, string image)
        {
            Name = name;
            Email = email;
            Password = password;
            Status = EUserStatus.Active;
            Birthdate = birthdate;
            Address = address;
            Image = image;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            _albums = new List<Album>();
            _songs = new List<Song>();
        }

        public User(Guid id, Name name, Email email, DateTime? birthdate, Address address, string image)
        : base(id)
        {
            Name = name;
            Email = email;
            Birthdate = birthdate;
            Address = address;
            Image= image;
            UpdatedAt = DateTime.Now;
            _albums = new List<Album>();
            _songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            if (song.IsValid)
                this._songs.Add(song);
        }

        public void AddAlbum(Album album)
        {
            if (album.IsValid && !_albums.Contains(album))
                this._albums.Add(album);
            else
                AddNotification("Album", "O album informado está inválido ou já existe na lista de albuns.");
        }

        public bool UploadImage(string file)
        {
            // TODO: Upload image to Azure.
            return false;
        }

        public void ChangeStatus(EUserStatus status)
        {
            if (this.Status != status)
                this.Status = status;
        }

        public override string ToString() => Name.ToString();
    }
}
