using System;
using System.Collections.Generic;
using Tone.Domain.Entities;

namespace Tone.Domain.Repositories
{
    public interface IGenderRepository
    {
        IList<Gender> GetList(string search);
        Gender GetById(Guid id);
        bool Create(Gender gender);
        bool Edit(Gender gender);
        bool Delete(Guid id);
    }
}