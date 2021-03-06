﻿using System;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Users;

namespace Tone.Domain.Repositories
{
    public interface IUserRepository
    {
        bool Create(User user);
        
        bool Update(User user);
        
        bool ChangeStatus(Guid id, int status);

        UserAuthQuery Login(string email, string password);

        bool Delete(Guid id);

        bool EmailExists(string email);
    }
}
