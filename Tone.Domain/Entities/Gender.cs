using System;
using FluentValidator.Validation;
using Tone.Domain.Utils;
using Tone.Shared.Entities;

namespace Tone.Domain.Entities
{
    public class Gender : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Gender(string title, string description)
        {
            Title = title ?? "";
            Description = description;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

            Validate();
        }

        public Gender(Guid id, string title, string description) : base(id)
        {
            Title = title ?? "";
            Description = description;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

            Validate();
        }

        public override string ToString() => this.Title;

        private void Validate()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(Title, 2, "Title", string.Format(MessagesUtil.MinLength, "Título", 2))
            );
        }
    }
}
