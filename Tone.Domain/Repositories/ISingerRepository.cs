using System;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Singers;

namespace Tone.Domain.Repositories
{
    public interface ISingerRepository
    {
        GetSingersQuery Get(string search);
        GetSingerByIdQuery GetById(Guid id);
        bool Create(Singer singer);
        bool Update(Singer singer);
        bool Delete(Guid id);
    }
}