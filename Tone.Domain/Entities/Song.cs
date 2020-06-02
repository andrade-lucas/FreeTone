using System;
using Tone.Shared.Entities;

namespace Tone.Domain.Entities
{
    public class Song : Entity
    {
        public string Title { get; private set; }
        public Singer Singer { get; private set; }
        public string Url { get; private set; }
        public int DownloadCounter { get; set; }
        public DateTime? PublishedDate { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Song(string title, Singer singer, string url, DateTime? publishedDate)
        {
            Title = title;
            Singer = singer;
            Url = url;
            PublishedDate = publishedDate;
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
