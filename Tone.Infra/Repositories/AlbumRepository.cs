using System;
using System.Collections.Generic;
using Tone.Domain.Entities;
using Tone.Domain.Repositories;

namespace Tone.Infra.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        public bool Create(Album album)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Album> Get(string search = "")
        {
            throw new NotImplementedException();
        }

        public Album GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Album album)
        {
            throw new NotImplementedException();
        }
    }
}