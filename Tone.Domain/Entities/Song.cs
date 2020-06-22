using System;
using Tone.Shared.Entities;

namespace Tone.Domain.Entities
{
    public class Song : Entity
    {
        public string Title { get; private set; }
        public Singer Singer { get; private set; }
        public Album Album { get; private set; }
        public string Url { get; private set; }
        public int DownloadCounter { get; set; }
        public DateTime? PublishedDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Song(string title, Singer singer, Album album, string url, DateTime? publishedDate)
        {
            Title = title;
            Singer = singer;
            Album = album;
            Url = url;
            PublishedDate = publishedDate;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Song(Guid id, string title, Singer singer, Album album, string url, DateTime? publishedDate) : base(id)
        {
            Title = title;
            Singer = singer;
            Album = album;
            Url = url;
            PublishedDate = publishedDate;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public bool Upload(string url)
        {
            return false;
        }

        public void Download()
        {
            DownloadCounter++;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
