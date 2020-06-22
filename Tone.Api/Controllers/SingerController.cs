using System;
using Microsoft.AspNetCore.Mvc;
using Tone.Domain.Commands.Handlers;
using Tone.Domain.Commands.Inputs.singers;
using Tone.Domain.Commands.Inputs.Singers;
using Tone.Domain.Entities;
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
        [Route("singers")]
        public GetSingersQuery Get(string search)
        {
            return _repository.Get(search);
        }

        [HttpGet]
        [Route("singers/{id}")]
        public Singer GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        [Route("singers")]
        public ICommandResult Create([FromBody]CreateSingerCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("singers/{id}")]
        public ICommandResult Delete(DeleteSingerCommand command)
        {
            return _handler.Handle(command);
        }
    }
}