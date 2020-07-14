using System;
using System.Collections.Generic;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Genders;

namespace Tone.Domain.Repositories
{
    public interface IGenderRepository
    {
        IList<GetGendersQuery> Get();
        Gender GetById(Guid id);
        bool Create(Gender gender);
        bool Edit(Gender gender);
        bool Delete(Guid id);
    }
}