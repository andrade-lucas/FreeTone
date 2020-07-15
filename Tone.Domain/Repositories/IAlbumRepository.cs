using System;
using System.Collections.Generic;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Albums;

namespace Tone.Domain.Repositories
{
    public interface IAlbumRepository
    {
        IList<GetAlbumsQuery> Get();
        GetAlbumByIdQuery GetById(Guid id);
        bool Create(Album album);
        bool Update(Album album);
        bool Delete(Guid id);
    }
}