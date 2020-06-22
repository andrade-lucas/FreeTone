using System;
using System.Collections.Generic;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Songs;

namespace Tone.Domain.Repositories
{
    public interface ISongRepository
    {
        IList<GetSongsQuery> Get(string search = "");
        GetSongByIdQuery GetById(Guid id);
        bool Create(Song song);
        bool Update(Song song);
        bool Delete(Guid id);
    }
}