using System;
using System.Collections.Generic;
using Tone.Domain.Entities;

namespace Tone.Domain.Repositories
{
    public interface IAlbumRepository
    {
        IList<Album> Get(string search = "");
        Album GetById(Guid id);
        bool Create(Album album);
        bool Edit(Album album);
        bool Delete(Guid id);
    }
}