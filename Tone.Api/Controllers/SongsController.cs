using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tone.Domain.Commands.Handlers;
using Tone.Domain.Commands.Inputs.Songs;
using Tone.Domain.Queries.Songs;
using Tone.Domain.Repositories;
using Tone.Shared.Commands;

namespace Tone.Api.Controllers
{
    public class SongsController : Controller
    {
        private readonly ISongRepository _songRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly ISingerRepository _singerRepository;
        private readonly SongHandler _handler;

        public SongsController(ISongRepository songRepository, IAlbumRepository albumRepository, ISingerRepository singerRepository)
        {
            this._songRepository = songRepository;
            this._albumRepository = albumRepository;
            this._singerRepository = singerRepository;
            this._handler = new SongHandler(_songRepository, _albumRepository, _singerRepository);
        }

        [HttpGet]
        [Route("v1/songs")]
        public IList<GetSongsQuery> Get()
        {
            return _songRepository.Get();
        }

        [HttpGet]
        [Route("v1/songs/{id}")]
        public GetSongByIdQuery GetById(Guid id)
        {
            return _songRepository.GetById(id);
        }

        [HttpPost]
        [Route("v1/songs")]
        public ICommandResult Create([FromBody]CreateSongCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/songs/{id}")]
        public ICommandResult Update([FromBody]UpdateSongCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/songs/{id}")]
        public ICommandResult Delete(DeleteSongCommand command)
        {
            return _handler.Handle(command);
        }
    }
}