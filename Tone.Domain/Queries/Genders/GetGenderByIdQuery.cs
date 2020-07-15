using System;

namespace Tone.Domain.Queries.Genders
{
    public class GetGenderByIdQuery
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}