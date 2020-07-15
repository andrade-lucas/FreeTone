using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tone.Domain.Commands.Handlers;
using Tone.Domain.Commands.Inputs.Genders;
using Tone.Domain.Queries.Genders;
using Tone.Domain.Repositories;
using Tone.Shared.Commands;

namespace Tone.Api.Controllers
{
    public class GendersController : Controller
    {
        private readonly IGenderRepository _repository;
        private readonly GenderHandler _handler;

        public GendersController(IGenderRepository repository)
        {
            this._repository = repository;
            _handler = new GenderHandler(_repository);
        }

        [HttpGet]
        [Route("v1/genders")]
        public IList<GetGendersQuery> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/genders/{id}")]
        public GetGenderByIdQuery GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        [Route("v1/genders")]
        public ICommandResult Create([FromBody]CreateGenderCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/genders/{id}")]
        public ICommandResult Update([FromBody]UpdateGenderCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/genders/{id}")]
        public ICommandResult Delete(DeleteGenderCommand command)
        {
            return _handler.Handle(command);
        }
    }
}