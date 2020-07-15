using System;
using System.Collections.Generic;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Genders;

namespace Tone.Domain.Repositories
{
    public interface IGenderRepository
    {
        IList<GetGendersQuery> Get();
        GetGenderByIdQuery GetById(Guid id);
        bool Create(Gender gender);
        bool Update(Gender gender);
        bool Delete(Guid id);
    }
}