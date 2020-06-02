using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tone.Domain.Commands.Handlers;
using Tone.Domain.Commands.Inputs.Categories;
using Tone.Domain.Entities;
using Tone.Domain.Repositories;
using Tone.Shared.Commands;

namespace Tone.Api.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _repository;
        private readonly CategoryHandler _handler;

        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
            _handler = new CategoryHandler(_repository);
        }

        [HttpGet]
        [Route("categories")]
        public IList<Category> Get(string search)
        {
            return _repository.Get(search);
        }

        [HttpGet]
        [Route("categories/{id}")]
        public Category GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        [Route("categories")]
        public ICommandResult Create([FromBody]CreateCategoryCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("categories")]
        public ICommandResult Update([FromBody]UpdateCategoryCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("categories")]
        public ICommandResult Delete(DeleteCategoryCommand command)
        {
            return _handler.Handle(command);
        }
    }
}