using System;

namespace Tone.Domain.Queries.Categories
{
    public class GetCategoryByIdQuery
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}