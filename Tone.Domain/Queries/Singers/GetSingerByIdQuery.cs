using System;

namespace Tone.Domain.Queries.Singers
{
    public class GetSingerByIdQuery
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
    }
}