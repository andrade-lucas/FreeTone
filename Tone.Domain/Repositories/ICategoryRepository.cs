using System;
using System.Collections.Generic;
using Tone.Domain.Entities;

namespace Tone.Domain.Repositories
{
    public interface ICategoryRepository
    {
        IList<Category> Get(string search);
        Category GetById(Guid id);
        bool Create(Category category);
        bool Update(Category category);
        bool Delete(Guid id);
    }
}