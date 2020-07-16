using System;
using System.Linq;
using System.Collections.Generic;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Genders;
using Tone.Domain.Repositories;
using Tone.Infra.Context;
using Dapper;

namespace Tone.Infra.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly IDB _db;

        public GenderRepository(IDB db)
        {
            this._db = db;
        }
        
        public bool Create(Gender gender)
        {
            int affectedRows = _db.Connection().Execute(
                "insert into [Gender] (Id, Title, Description, CreatedAt, UpdatedAt) values(@id, @title, " +
                "@description, @createdAt, @updatedAt)",
                new
                {
                    id = gender.Id,
                    title = gender.Title,
                    description = gender.Description,
                    createdAt = gender.CreatedAt,
                    updatedAt = gender.UpdatedAt
                }
            );

            return affectedRows > 0;
        }

        public bool Delete(Guid id)
        {
            int affectedRows = _db.Connection().Execute(
                "delete from [Gender] where Id = @id",
                new
                {
                    id = id
                }
            );

            return affectedRows > 0;
        }

        public bool Update(Gender gender)
        {
            int affectedRows = _db.Connection().Execute(
                "update [Gender] set Title = @title, Description = @description, UpdatedAt = @updatedAt where Id = @id",
                new
                {
                    id = gender.Id,
                    title = gender.Title,
                    description = gender.Description,
                    updatedAt = gender.UpdatedAt
                }
            );

            return affectedRows > 0;
        }

        public GetGenderByIdQuery GetById(Guid id)
        {
            return _db.Connection().QuerySingleOrDefault<GetGenderByIdQuery>(
                "select Id, Title, Description from [Gender] where Id = @id",
                new
                {
                    id = id
                }
            );
        }

        public IList<GetGendersQuery> Get()
        {
            return _db.Connection().Query<GetGendersQuery>(
                "select Id, Title from [Gender]"
            ).ToList();
        }
    }
}