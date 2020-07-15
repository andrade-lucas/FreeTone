using System;

namespace Tone.Domain.Queries.Singers
{
    public class GetSingersQuery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Image { get; set; }
    }
}