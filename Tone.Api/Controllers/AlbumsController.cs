using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tone.Domain.Commands.Handlers;
using Tone.Domain.Commands.Inputs.Albums;
using Tone.Domain.Queries.Albums;
using Tone.Domain.Repositories;
using Tone.Shared.Commands;

namespace Tone.Api.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly AlbumHandler _handler;

        public AlbumsController(IAlbumRepository albumRepository, IGenderRepository genderRepository, ICategoryRepository categoryRepository)
        {
            this._albumRepository = albumRepository;
            this._genderRepository = genderRepository;
            this._categoryRepository = categoryRepository;
            this._handler = new AlbumHandler(_albumRepository, _genderRepository, _categoryRepository);
        }
        
        [HttpGet]
        [Route("v1/albums")]
        public IList<GetAlbumsQuery> Get()
        {
            return _albumRepository.Get();
        }

        [HttpGet]
        [Route("v1/albums/{id}")]
        public GetAlbumByIdQuery GetById(Guid id)
        {
            return _albumRepository.GetById(id);
        }

        [HttpPost]
        [Route("v1/albums")]
        public ICommandResult Create([FromBody]CreateAlbumCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/albums/{id}")]
        public ICommandResult Update([FromBody]UpdateAlbumCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/albums/{id}")]
        public ICommandResult Delete(DeleteAlbumCommand command)
        {
            return _handler.Handle(command);
        }
    }
}