using System;
using Tone.Domain.Utils;
using Tone.Shared.Entities;

namespace Tone.Domain.Entities
{
    public class Category : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Category(string title, string description)
        {
            Title = title;
            Description = description;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

            Validate();
        }

        public Category(Guid id, string title, string description) : base(id)
        {
            Title = title;
            Description = description;
            UpdatedAt = DateTime.Now;

            Validate();
        }

        public override string ToString()
        {
            return Title;
        }

        private void Validate()
        {
            if (Title.Length < 3)
                AddNotification("Title", string.Format(MessagesUtil.MinLength, "Título", 3));
        }
    }
}
