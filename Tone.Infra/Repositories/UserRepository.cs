using System;
using Tone.Domain.Entities;
using Tone.Domain.Repositories;
using Tone.Infra.Context;
using Dapper;

namespace Tone.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDB _db;

        public UserRepository(IDB db)
        {
            _db = db;
        }

        public bool ChangeStatus(Guid id, int status)
        {
            throw new NotImplementedException();
        }

        public bool Create(User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(User user)
        {
            throw new NotImplementedException();
        }

        public User Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}