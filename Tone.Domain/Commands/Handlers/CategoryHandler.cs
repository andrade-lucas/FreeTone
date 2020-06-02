using FluentValidator;
using Tone.Domain.Commands.Inputs.Categories;
using Tone.Domain.Commands.Outputs;
using Tone.Domain.Entities;
using Tone.Domain.Repositories;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Handlers
{
    public class CategoryHandler : Notifiable, ICommandHandler<CreateCategoryCommand>,
    ICommandHandler<UpdateCategoryCommand>, ICommandHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _repository;

        public CategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateCategoryCommand command)
        {
            var category = new Category(command.Title, command.Description);
            AddNotifications(category.Notifications);

            if (Invalid)
                return new CommandResult(false, "Falha ao cadastrar Categoria", Notifications);
            
            bool result = _repository.Create(category);
            
            if (!result)
                return new CommandResult(false, "Falha ao cadastrar Categoria");

            return new CommandResult(true, "Categoria cadastrada com sucesso");
        }

        public ICommandResult Handle(UpdateCategoryCommand command)
        {
            var category = new Category(command.Id, command.Title, command.Description);
            AddNotifications(category.Notifications);

            if (Invalid)
                return new CommandResult(false, "Falha ao atualizar Categoria", Notifications);

            bool result = _repository.Update(category);
            if (!result)
                return new CommandResult(false, "Falha ao atualizar Categoria");
            
            return new CommandResult(true, "Categoria atualizada com sucesso");
        }

        public ICommandResult Handle(DeleteCategoryCommand command)
        {
            bool result = _repository.Delete(command.Id);

            if (!result)
                return new CommandResult(false, "Falha ao deletar Categoria");

            return new CommandResult(true, "Categoria deletada com sucesso!");
        }
    }
}