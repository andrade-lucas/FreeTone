using System;
using Tone.Shared.Entities;

namespace Tone.Domain.Entities
{
    public class Gender : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public Gender(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public Gender(Guid id, string title, string description) : base(id)
        {
            Title = title;
            Description = description;
        }
    }
}
