using System;
using System.Linq;
using System.Collections.Generic;
using Tone.Domain.Entities;
using Tone.Domain.Repositories;
using Tone.Infra.Context;
using Dapper;
using Tone.Domain.Queries.Categories;

namespace Tone.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDB _db;

        public CategoryRepository(IDB db)
        {
            this._db = db;
        }
        
        public bool Create(Category category)
        {
            int affectedRows = _db.Connection().Execute(
                "insert into [Category] (Id, Title, Description, CreatedAt, UpdatedAt) values(@id, @title, @description, @createdAt, @updatedAt)",
                new
                {
                    id = category.Id,
                    title = category.Title,
                    description = category.Description,
                    createdAt = category.CreatedAt,
                    updatedAt = category.UpdatedAt
                }
            );

            return affectedRows > 0;
        }

        public bool Delete(Guid id)
        {
            int affectedRows = _db.Connection().Execute(
                "delete from [Category] where Id = @id",
                new
                {
                    id = id
                }
            );

            return affectedRows > 0;
        }

        public IList<GetCategoriesQuery> Get()
        {
            return _db.Connection().Query<GetCategoriesQuery>(
                "select Id, Title from [Category]"
            ).ToList();
        }

        public GetCategoryByIdQuery GetById(Guid id)
        {
            return _db.Connection().QueryFirstOrDefault<GetCategoryByIdQuery>(
                "select * from [Category] where Id = @id",
                new
                {
                    id = id
                }
            );
        }

        public bool Update(Category category)
        {
            int affectedRows = _db.Connection().Execute(
                "update [Category] set Title = @title, Description = @description, UpdatedAt = @updatedAt where Id = @id",
                new
                {
                    id = category.Id,
                    title = category.Title,
                    description = category.Description,
                    updatedAt = category.UpdatedAt
                }
            );

            return affectedRows > 0;
        }
    }
}