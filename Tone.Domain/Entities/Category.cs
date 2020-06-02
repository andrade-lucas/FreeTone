using System;
using Tone.Shared.Entities;

namespace Tone.Domain.Entities
{
    public class Category : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; set; }

        public Category(string title, string description)
        {
            Title = title;
            Description = description;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Category(Guid id, string title, string description)
        {
            Title = title;
            Description = description;
            UpdatedAt = UpdatedAt;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
