using System;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Singers;
using Tone.Domain.Repositories;
using Tone.Infra.Context;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace Tone.Infra.Repositories
{
    public class SingerRepository : ISingerRepository
    {
        private readonly IDB _db;

        public SingerRepository(IDB db)
        {
            this._db = db;
        }
        
        public bool Create(Singer singer)
        {
            int affectedRows = _db.Connection().Execute(
                "insert into [Singer](Id, FirstName, LastName, Nationality, About, Image, CreatedAt, UpdatedAt) " +
                "values(@id, @firstName, @lastName, @nationality, @about, @image, @createdAt, @updatedAt)",
                new
                {
                    id = singer.Id,
                    firstName = singer.Name.FirstName,
                    lastName = singer.Name.LastName,
                    nationality = singer.Nationality,
                    about = singer.About,
                    image = singer.Image,
                    createdAt = singer.CreatedAt,
                    updatedAt = singer.UpdatedAt
                }
            );

            return affectedRows > 0;
        }

        public bool Delete(Guid id)
        {
            int affectedRows = _db.Connection().Execute(
                "delete from [Singer] where Id = @id",
                new
                {
                    id = id
                }
            );

            return affectedRows > 0;
        }

        public IList<GetSingersQuery> Get()
        {
            return _db.Connection().Query<GetSingersQuery>(
                "select Id, concat(FirstName, ' ', LastName) Name, Nationality, Image from [Singer]"
            ).ToList();
        }

        public GetSingerByIdQuery GetById(Guid id)
        {
            return _db.Connection().QuerySingleOrDefault<GetSingerByIdQuery>(
                "select Id, FirstName, LastName, Nationality, About, Image from [Singer] where Id = @id",
                new
                {
                    id = id
                }
            );
        }

        public bool Update(Singer singer)
        {
            int affectedRows = _db.Connection().Execute(
                "update [Singer] set FirstName = @firstName, LastName = @lastName, Nationality = @nationality, " +
                "About = @about, Image = @image, UpdatedAt = @updatedAt where Id = @id",
                new
                {
                    id = singer.Id,
                    firstName = singer.Name.FirstName,
                    lastName = singer.Name.LastName,
                    nationality = singer.Nationality,
                    about = singer.About,
                    image = singer.Image,
                    updatedAt = singer.UpdatedAt
                }
            );

            return affectedRows > 0;
        }
    }
}