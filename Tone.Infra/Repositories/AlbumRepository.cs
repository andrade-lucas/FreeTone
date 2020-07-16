using System;
using System.Collections.Generic;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Albums;
using Tone.Domain.Repositories;
using Tone.Infra.Context;
using Dapper;
using System.Linq;

namespace Tone.Infra.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly IDB _db;

        public AlbumRepository(IDB db)
        {
            this._db = db;
        }
        
        public bool Create(Album album)
        {
            int affectedRows = _db.Connection().Execute(
                "insert into [Album](Id, Title, GenderId, CategoryId, Image, CreatedAt, UpdatedAt)" + 
                "values(@id, @title, @genderId, @categoryId, @image, @createdAt, @updatedAt)",
                new
                {
                    id = album.Id,
                    title = album.Title,
                    genderId = album.Gender.Id,
                    categoryId = album.Category.Id,
                    image = album.Image,
                    createdAt = album.CreatedAt,
                    updatedAt = album.UpdatedAt
                }
            );

            return affectedRows > 0;
        }

        public bool Delete(Guid id)
        {
            int affectedRows = _db.Connection().Execute(
                "delete from [Album] where Id = @id",
                new
                {
                    id = id
                }
            );

            return affectedRows > 0;
        }

        public IList<GetAlbumsQuery> Get()
        {
            return _db.Connection().Query<GetAlbumsQuery>(
                "select Id, Title, Image from [Album]"
            ).ToList();
        }

        public GetAlbumByIdQuery GetById(Guid id)
        {
            return _db.Connection().QuerySingleOrDefault<GetAlbumByIdQuery>(
                "select Id, Title, GenderId, CategoryId, Image from [Album] where Id = @id",
                new
                {
                    id = id
                }
            );
        }

        public bool Update(Album album)
        {
            int affectedRows = _db.Connection().Execute(
                "update [Album] set Title = @title, GenderId = @genderId, CategoryId = @categoryId, " +
                "Image = @image, UpdatedAt = @updatedAt where Id = @id",
                new
                {
                    id = album.Id,
                    title = album.Title,
                    genderId = album.Gender.Id,
                    categoryId = album.Category.Id,
                    image = album.Image,
                    updatedAt = album.UpdatedAt
                }
            );

            return affectedRows > 0;
        }
    }
}