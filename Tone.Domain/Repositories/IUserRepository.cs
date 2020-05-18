using System;
using System.Collections.Generic;
using System.Text;
using Tone.Domain.Entities;

namespace Tone.Domain.Repositories
{
    public interface IUserRepository
    {
        bool Create(User user);
        
        bool Edit(User user);
        
        bool ChangeStatus(Guid id, int status);

        User Login(string email, string password);

        bool Delete(Guid id);
    }
}
