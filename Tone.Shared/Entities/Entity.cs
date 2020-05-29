using System;
using FluentValidator;

namespace Tone.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Entity(Guid id)
        {
            Id = id;
        }
    }
}
