using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tone.Domain.Commands.Handlers;
using Tone.Domain.Queries.Genders;
using Tone.Domain.Repositories;

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
    }
}