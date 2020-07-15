using FluentValidator;
using Tone.Domain.Commands.Inputs.Genders;
using Tone.Domain.Commands.Outputs;
using Tone.Domain.Entities;
using Tone.Domain.Repositories;
using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Handlers
{
    public class GenderHandler : Notifiable, ICommandHandler<CreateGenderCommand>,
    ICommandHandler<UpdateGenderCommand>, ICommandHandler<DeleteGenderCommand>
    {
        private readonly IGenderRepository _repository;

        public GenderHandler(IGenderRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateGenderCommand command)
        {
            Gender gender = new Gender(command.Title, command.Description);

            AddNotifications(gender.Notifications);

            if (Invalid)
                return new CommandResult(false, "Por favor, verifique se todos os campos estão preenchidos corretamente!", Notifications);

            bool result = _repository.Create(gender);
            if (!result)
                return new CommandResult(false, "Ocorreu um erro ao cadastrar o gênero!", Notifications);

            return new CommandResult(true, "Gênero cadastrado com sucesso!");
        }

        public ICommandResult Handle(UpdateGenderCommand command)
        {
            Gender gender = new Gender(command.Id, command.Title, command.Description);

            AddNotifications(gender.Notifications);

            if (Invalid)
                return new CommandResult(false, "Por favor, verifique se todos os campos estão preenchidos corretamente!", Notifications);

            bool result = _repository.Update(gender);
            if (!result)
                return new CommandResult(false, "Ocorreu um erro ao modificar o gênero!", Notifications);

            return new CommandResult(true, "Gênero modificado com sucesso!");
        }

        public ICommandResult Handle(DeleteGenderCommand command)
        {
            if (command.Id.ToString().Length == 0)
                AddNotification("Id", "Identificador inválido!");

            if (Invalid)
                return new CommandResult(false, "Erro ao deletar gênero!", Notifications);

            bool result = _repository.Delete(command.Id);

            if (!result)
                return new CommandResult(false, "Erro ao deletar gênero!", Notifications);

            return new CommandResult(true, "Gênero deletado com sucesso!");
        }
    }
}