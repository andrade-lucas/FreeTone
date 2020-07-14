using System;

namespace Tone.Domain.Queries.Categories
{
    public class GetCategoriesQuery
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}