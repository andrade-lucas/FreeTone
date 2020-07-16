using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tone.Domain.Commands.Handlers;
using Tone.Domain.Commands.Inputs.singers;
using Tone.Domain.Commands.Inputs.Singers;
using Tone.Domain.Queries.Singers;
using Tone.Domain.Repositories;
using Tone.Shared.Commands;

namespace Tone.Api.Controllers
{
    public class SingerController : Controller
    {
        private readonly ISingerRepository _repository;
        private readonly SingerHandler _handler;

        public SingerController(ISingerRepository repository)
        {
            _repository = repository;
            _handler = new SingerHandler(repository);
        }

        [HttpGet]
        [Route("v1/singers")]
        public IList<GetSingersQuery> Get(string search)
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/singers/{id}")]
        public GetSingerByIdQuery GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        [Route("v1/singers")]
        public ICommandResult Create([FromBody]CreateSingerCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/singers/{id}")]
        public ICommandResult Update([FromBody]UpdateSingerCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/singers/{id}")]
        public ICommandResult Delete(DeleteSingerCommand command)
        {
            return _handler.Handle(command);
        }
    }
}