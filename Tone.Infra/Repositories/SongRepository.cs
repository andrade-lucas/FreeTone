using System;
using System.Collections.Generic;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Songs;
using Tone.Domain.Repositories;

namespace Tone.Infra.Repositories
{
    public class SongRepository : ISongRepository
    {
        public bool Create(Song song)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<GetSongsQuery> Get(string search = "")
        {
            throw new NotImplementedException();
        }

        public GetSongByIdQuery GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Song song)
        {
            throw new NotImplementedException();
        }
    }
}