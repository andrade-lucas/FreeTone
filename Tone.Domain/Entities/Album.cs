using Tone.Shared.Entities;

namespace Tone.Domain.Entities
{
    public class Album : Entity
    {
        public string Title { get; private set; }
        public Gender Gender { get; private set; }
        public Category Category { get; private set; }
    }
}