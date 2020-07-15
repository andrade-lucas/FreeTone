using System;
using System.Collections.Generic;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Singers;

namespace Tone.Domain.Repositories
{
    public interface ISingerRepository
    {
        IList<GetSingersQuery> Get();
        GetSingerByIdQuery GetById(Guid id);
        bool Create(Singer singer);
        bool Update(Singer singer);
        bool Delete(Guid id);
    }
}