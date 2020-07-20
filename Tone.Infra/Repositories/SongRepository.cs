using System;
using System.Linq;
using System.Collections.Generic;
using Tone.Domain.Entities;
using Tone.Domain.Queries.Songs;
using Tone.Domain.Repositories;
using Tone.Infra.Context;
using Dapper;

namespace Tone.Infra.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly IDB _db;

        public SongRepository(IDB db)
        {
            this._db = db;
        }
        
        public bool Create(Song song)
        {
            int affectedRows = _db.Connection().Execute(
                "insert into [Song](Id, Title, SingerId, AlbumId, Url, DownloadCounter, PublishedDate, CreatedAt, UpdatedAt) " +
                "values(@id, @title, @singerId, @albumId, @url, @downloadCounter, @publishedDate, @createdAt, @updatedAt)",
                new
                {
                    id = song.Id,
                    title = song.Title,
                    singerId = song.Singer.Id,
                    albumId = song.Album.Id,
                    url = song.Url,
                    downloadCounter = song.DownloadCounter,
                    publishedDate = song.PublishedDate,
                    createdAt = song.CreatedAt,
                    updatedAt = song.UpdatedAt
                }
            );

            return affectedRows > 0;
        }

        public bool Delete(Guid id)
        {
            int affectedRows = _db.Connection().Execute(
                "delete from [Song] where Id = @id",
                new
                {
                    id = id
                }
            );

            return affectedRows > 0;
        }

        public IList<GetSongsQuery> Get()
        {
            return _db.Connection().Query<GetSongsQuery>(
                "select Song.Id, Song.Title, concat(Singer.FirstName, ' ', Singer.LastName) Singer, Album.Title Album from [Song] " +
                "inner join Singer on Singer.Id = Song.SingerId " +
                "inner join Album on Album.Id = Song.AlbumId"
            ).ToList();
        }

        public IList<GetSongsByAlbumQuery> GetByAlbum(Guid albumId)
        {
            return _db.Connection().Query<GetSongsByAlbumQuery>(
                "select Song.Id, Song.Title, Song.Url, SingerId, Singer.FirstName SingerFirstName, Singer.LastName SingerLastName, Singer.Image SingerImage from [Song] " +
                "inner join Singer on Singer.Id = Song.SingerId " +
                "where AlbumId = @albumId",
                new
                {
                    albumId = albumId
                }
            ).ToList();
        }

        public GetSongByIdQuery GetById(Guid id)
        {
            return _db.Connection().QuerySingleOrDefault<GetSongByIdQuery>(
                "select Id, Title, SingerId, AlbumId, Url, DownloadCounter, PublishedDate from [Song] where Id = @id",
                new
                {
                    id = id
                }
            );
        }

        public bool Update(Song song)
        {
            int affectedRows = _db.Connection().Execute(
                "update [Song] set Title = @title, SingerId = @singerId, AlbumId = @albumId, Url = @url, DownloadCounter = @downloadCounter, " +
                "PublishedDate = @publishedDate, UpdatedAt = @updatedAt where Id = @id",
                new
                {
                    id = song.Id,
                    title = song.Title,
                    singerId = song.Singer.Id,
                    albumId = song.Album.Id,
                    url = song.Url,
                    downloadCounter = song.DownloadCounter,
                    publishedDate = song.PublishedDate,
                    updatedAt = song.UpdatedAt
                }
            );

            return affectedRows > 0;
        }
    }
}