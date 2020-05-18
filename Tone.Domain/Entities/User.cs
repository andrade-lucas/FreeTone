using System;
using Tone.Domain.ValueObjects;
using Tone.Shared.Entities;

namespace Tone.Domain.Entities
{
    public class User : Entity
    {
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public int Status { get; private set; }
        public DateTime Birthday { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
