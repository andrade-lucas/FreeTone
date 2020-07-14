using System;
using System.Collections.Generic;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Genders;
using Tone.Domain.Repositories;

namespace Tone.Infra.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        public bool Create(Gender gender)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Gender gender)
        {
            throw new NotImplementedException();
        }

        public Gender GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<GetGendersQuery> Get()
        {
            throw new NotImplementedException();
        }
    }
}