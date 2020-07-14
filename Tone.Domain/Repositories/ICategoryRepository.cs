using System;
using System.Collections.Generic;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Categories;

namespace Tone.Domain.Repositories
{
    public interface ICategoryRepository
    {
        IList<GetCategoriesQuery> Get();
        GetCategoryByIdQuery GetById(Guid id);
        bool Create(Category category);
        bool Update(Category category);
        bool Delete(Guid id);
    }
}