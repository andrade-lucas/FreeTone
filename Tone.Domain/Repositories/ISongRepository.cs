using System;
using System.Collections.Generic;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Songs;

namespace Tone.Domain.Repositories
{
    public interface ISongRepository
    {
        IList<GetSongsQuery> Get();
        IList<GetSongsByAlbumQuery> GetByAlbum(Guid albumId);
        GetSongByIdQuery GetById(Guid id);
        bool Create(Song song);
        bool Update(Song song);
        bool Delete(Guid id);
    }
}