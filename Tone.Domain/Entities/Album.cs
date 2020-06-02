using System;
using System.Collections.Generic;
using System.Linq;
using Tone.Shared.Entities;

namespace Tone.Domain.Entities
{
    public class Album : Entity
    {
        private readonly IList<Song> _songs;
        
        public string Title { get; private set; }
        public Gender Gender { get; private set; }
        public Category Category { get; private set; }
        public string Image { get; private set; }
        public IEnumerable<Song> Songs => this._songs.ToList();
        public DateTime UpdatedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Album(string title, Gender gender, Category category, string image)
        {
            Title = title;
            Gender = gender;
            Category = category;
            Image = image;
            _songs = new List<Song>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Album(Guid id, Gender gender, Category category, string image) : base(id)
        {
            Gender = gender;
            Category = category;
            Image = image;
            UpdatedAt = DateTime.Now;
        }

        public bool UploadImage(string file)
        {
            // TODO: Upload image to Azure.
            return false;
        }

        public void AddSong(Song song)
        {
            if (song.IsValid)
                this._songs.Add(song);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}