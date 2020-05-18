using System;
using System.Collections.Generic;
using System.Text;
using Tone.Shared.Entities;

namespace Tone.Domain.Entities
{
    public class Category : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
    }
}
