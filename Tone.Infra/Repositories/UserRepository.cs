using System;
using Tone.Domain.Entities;
using Tone.Domain.Repositories;
using Tone.Infra.Context;
using Dapper;
using Tone.Domain.Queries.Users;

namespace Tone.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDB _db;

        public UserRepository(IDB db)
        {
            this._db = db;
        }

        public bool ChangeStatus(Guid id, int status)
        {
            int affectedRows = _db.Connection().Execute(
                "update [User] set Status = @status where Id = @id",
                new
                {
                    id = id,
                    status = status
                }
            );

            return affectedRows > 0;
        }

        public bool Create(User user)
        {
            int result = _db.Connection().Execute(
                "insert into [User] (Id, FirstName, LastName, Email, Password, Status, Birthdate, Street, Number, " +
                "Neighborhood, City, State, Country, ZipCode, Image, CreatedAt, UpdatedAt) values (@id, @firstName, @lastName, " +
                "@email, @password, @status, @birthdate, @street, @number, @neighborhood, @city, @state, @country, " +
                "@zipCode, @image, @createdAt, @updatedAt)",
                new
                {
                    id = user.Id,
                    firstName = user.Name.FirstName,
                    lastName = user.Name.LastName,
                    email = user.Email.Address,
                    password = user.Password.Value,
                    status = user.Status,
                    birthdate = user.Birthdate,
                    street = user.Address.Street,
                    number = user.Address.Number,
                    neighborhood = user.Address.Neighborhood,
                    city = user.Address.City,
                    state = user.Address.State,
                    country = user.Address.Country,
                    zipCode = user.Address.ZipCode,
                    image = user.Image,
                    createdAt = user.CreatedAt,
                    updatedAt = user.UpdatedAt
                }
            );

            return result > 0;
        }

        public bool Delete(Guid id)
        {
            int affectedRows = _db.Connection().Execute(
                "delete from [User] where Id = @id",
                new
                {
                    id = id
                }
            );

            return affectedRows > 0;
        }

        public bool Update(User user)
        {
            int affectedRows = _db.Connection().Execute(
                "update [User] set FirstName = @firstName, LastName = @lastName, Birthdate = @birthdate, Street = @street, " +
                "Number = @number, Neighborhood = @neighborhood, City = @city, State = @state, Country = @country, " +
                "ZipCode = @zipCode, Image = @image, UpdatedAt = @updatedAt where Id = @id",
                new
                {
                    id = user.Id,
                    firstName = user.Name.FirstName,
                    lastName = user.Name.LastName,
                    birthdate = user.Birthdate,
                    street = user.Address.Street,
                    number = user.Address.Number,
                    neighborhood = user.Address.Neighborhood,
                    city = user.Address.City,
                    state = user.Address.State,
                    country = user.Address.Country,
                    zipCode = user.Address.ZipCode,
                    image = user.Image,
                    updatedAt = user.UpdatedAt
                }
            );

            return affectedRows > 0;
        }

        public UserAuthQuery Login(string email, string password)
        {
            return _db.Connection().QuerySingle<UserAuthQuery>(
                "select Id, FirstName, LastName, Email, Image from [User] where Email = @email and Password = @password",
                new
                {
                    email = email,
                    password = password
                }
            );
        }
    }
}