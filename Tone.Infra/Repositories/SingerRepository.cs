using System;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Singers;
using Tone.Domain.Repositories;

namespace Tone.Infra.Repositories
{
    public class SingerRepository : ISingerRepository
    {
        public bool Create(Singer singer)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public GetSingersQuery Get(string search)
        {
            throw new NotImplementedException();
        }

        public Singer GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Singer singer)
        {
            throw new NotImplementedException();
        }
    }
}